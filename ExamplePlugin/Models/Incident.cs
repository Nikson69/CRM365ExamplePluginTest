using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using System;

namespace ExamplePlugin.Models
{
    [EntityLogicalName(EntityLogicalName)]
    public class Incident : Entity
    {
        public Incident() : base(EntityLogicalName) { }
        public const string EntityLogicalName = "incident";
        [AttributeLogicalName(FieldNames.Id)]
        public override Guid Id
        {
            get { return base.GetAttributeValue<Guid>(FieldNames.Id); }
            set { base.SetAttributeValue(FieldNames.Id, base.Id = value); }
        }
        [AttributeLogicalName(FieldNames.StateCode)]
        public OptionSetValue StateCode
        {
            get => GetAttributeValue<OptionSetValue>(FieldNames.StateCode);
            set => SetAttributeValue(FieldNames.StateCode, value);
        }
        [AttributeLogicalName(FieldNames.OwnerId)]
        public EntityReference Owner
        {
            get => GetAttributeValue<EntityReference>(FieldNames.OwnerId);
            set => SetAttributeValue(FieldNames.OwnerId, value);
        }
        [AttributeLogicalName(FieldNames.CustomFieldId)]
        public EntityReference CustomFieldId
        {
            get => GetAttributeValue<EntityReference>(FieldNames.CustomFieldId);
            set => SetAttributeValue(FieldNames.CustomFieldId, value);
        }

        public struct FieldNames
        {
            public const string Id = "incidentid";
            public const string StateCode = "statecode";
            public const string CustomFieldId = "new_custom_fieldid";
            public const string OwnerId = "ownerid";
        }
    }
}
