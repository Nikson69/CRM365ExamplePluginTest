using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using System;

namespace ExamplePlugin.Models
{
    [EntityLogicalName(EntityLogicalName)]
    public class Team: Entity
    {
        public Team() : base(EntityLogicalName) { }
        public const string EntityLogicalName = "team";
        [AttributeLogicalName(FieldNames.Id)]
        public new Guid Id
        {
            get => GetAttributeValue<Guid>(FieldNames.Id);
            set => SetAttributeValue(FieldNames.Id, (base.Id = value));
        }
        [AttributeLogicalName(FieldNames.CustomFieldId)]
        public EntityReference CustomFieldId
        {
            get => GetAttributeValue<EntityReference>(FieldNames.CustomFieldId);
            set => SetAttributeValue(FieldNames.CustomFieldId, value);
        }
        [AttributeLogicalName(FieldNames.IsDefault)]
        public bool? IsDefault
        {
            get => GetAttributeValue<bool?>(FieldNames.IsDefault);
            set => SetAttributeValue(FieldNames.IsDefault, value);
        }

        public struct FieldNames
        {
            public const string Id = "teamid";
            public const string IsDefault = "isdefault";
            public const string CustomFieldId = "new_custom_fieldid";
        }
    }
}
