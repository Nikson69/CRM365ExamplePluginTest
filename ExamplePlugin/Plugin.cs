using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using ExamplePlugin.Models;
using System;
using System.Linq;

namespace ExamplePlugin
{
    [CrmPluginRegistration(
    message: MessageNameEnum.Assign,
    entityLogicalName: Incident.EntityLogicalName,
    stage: StageEnum.PreValidation,
    executionMode: ExecutionModeEnum.Synchronous,
    filteringAttributes: Incident.FieldNames.OwnerId,
    stepName: PluginStep,
    executionOrder: 1,
    isolationModel: IsolationModeEnum.Sandbox,
    Image1Type = ImageTypeEnum.PreImage,
    Image1Name = PreImage,
    Image1Attributes = Attributes)]
    public class Plugin : IPlugin
    {
        public const string PluginStep = nameof(PluginStep);
        public const string Target = nameof(Target);
        public const string PreImage = nameof(PreImage);
        public const string Assignee = nameof(Assignee);
        public const string Attributes = Incident.FieldNames.Id + "," + Incident.FieldNames.OwnerId + "," + Incident.FieldNames.CustomFieldId;

        public const string NOT_FOUND_MESSAGE = "NOT_FOUND_MESSAGE";

        public void Execute(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetPluginExecutionContext();
            var customFieldId = context.GetPreImage<Incident>(PreImage).CustomFieldId;
            var orgFactory = serviceProvider.GetOrganizationServiceFactory();
            var service = orgFactory.CreateOrganizationService(context.InitiatingUserId);
            
            if (customFieldId == null)
                return;

            var assignee = context.GetInputParameter<EntityReference>(Assignee);
            if (assignee.LogicalName != Team.EntityLogicalName)
                return;

            var customFieldTeamId = GetTeamCustomWorkgroup(service);
            if (customFieldTeamId.HasValue 
                && assignee.Id.Equals(customFieldTeamId.Value))
            {
                var team = FindTeam(service, customFieldId.Id);

                if (team != null)
                {
                    context.InputParameters[Assignee] = team;
                }
                else
                {
                    throw new InvalidPluginExecutionException(NOT_FOUND_MESSAGE);
                }
            }
        }

        private EntityReference FindTeam(IOrganizationService service, Guid customFieldId)
        {
            var query = new QueryExpression(Team.EntityLogicalName);
            query.TopCount = 1;            
            query.Criteria.AddCondition(Team.FieldNames.CustomFieldId, ConditionOperator.Equal , customFieldId);
            query.Criteria.AddCondition(Team.FieldNames.IsDefault, ConditionOperator.Equal, true);

            var team = service.RetrieveMultiple(query).Entities.FirstOrDefault();
            return team?.ToEntityReference();
        }

        private Guid? GetTeamCustomWorkgroup(IOrganizationService service)
        {
            Guid? result = null;
            var query = new QueryByAttribute(Config.EntityLogicalName);
            query.AddAttributeValue(Config.FieldNames.Name, Config.ConfigParameterKeys.Key);

            var config = service.RetrieveMultiple(query).Entities.FirstOrDefault();

            var configValue = config.GetAttributeValue<string>(Config.FieldNames.Value);

            if (Guid.TryParse(configValue, out Guid customFieldId))
                result = customFieldId;

            return result;
        }
    }
}