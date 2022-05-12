using Microsoft.Xrm.Sdk;
using System;
using Microsoft.Xrm.Sdk.Client;

namespace ExamplePlugin.Models
{
    [EntityLogicalName(EntityLogicalName)]
    public class Config: Entity
    {
        public Config() : base(EntityLogicalName) { }
        public const string EntityLogicalName = "new_config";
        [AttributeLogicalName(FieldNames.Id)]
        public new Guid Id
        {
            get => GetAttributeValue<Guid>(FieldNames.Id);
            set => SetAttributeValue(FieldNames.Id, (base.Id = value));
        }
        [AttributeLogicalName(FieldNames.Name)]
        public string Name
        {
            get => GetAttributeValue<string>(FieldNames.Name);
            set => SetAttributeValue(FieldNames.Name, value);
        }
        [AttributeLogicalName(FieldNames.Value)]
        public string Value
        {
            get => GetAttributeValue<string>(FieldNames.Value);
            set => SetAttributeValue(FieldNames.Value, value);
        }

        public struct FieldNames
        {
            public const string Id = "new_configid";
            public const string Name = "new_name";
            public const string Value = "new_value";
        }

        public struct ConfigParameterKeys
        {
            public const string Key = "Key";
        }
    }
}
