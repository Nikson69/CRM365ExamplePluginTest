using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using System;

namespace ExamplePlugin.Models
{
    [EntityLogicalName(EntityLogicalName)]
    public class Custom: Entity
    {
        public Custom() : base(EntityLogicalName) { }
        public const string EntityLogicalName = "new_custom";
        [AttributeLogicalName(FieldNames.Id)]
        public new Guid Id
        {
            get => GetAttributeValue<Guid>(FieldNames.Id);
            set => SetAttributeValue(FieldNames.Id, (base.Id = value));
        }

        public struct FieldNames
        {
            public const string Id = "new_customid";
            
        }
    }
}
