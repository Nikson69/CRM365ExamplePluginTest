using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using FakeXrmEasy;
using Microsoft.Xrm.Sdk;
using ExamplePlugin.Models;
using ExamplePlugin;

namespace ExamplePluginTests
{
    [TestClass()]
    public class PluginTests
    {
        public static Guid Key = Guid.NewGuid();
        public static string SystemUser = nameof(SystemUser);
        [TestMethod()]
        public void Test1()
        {
            // setup 
            var context = new XrmFakedContext();
            var executionContext = context.GetDefaultPluginContext();
            var customRef = new EntityReference(Custom.EntityLogicalName, Guid.NewGuid());
            var teamId = Guid.NewGuid();
            var team = new Entity(Team.EntityLogicalName, teamId)
            {
                [Team.FieldNames.Id] = teamId,
                [Team.FieldNames.CustomFieldId] = customRef,
                [Team.FieldNames.IsDefault] = true
            };
            var incidentId = Guid.NewGuid();
            var incident = new Entity(Incident.EntityLogicalName, incidentId)
            {
                [Incident.FieldNames.Id] = incidentId,
                [Incident.FieldNames.CustomFieldId] = customRef,
            };

            var assignee = new EntityReference(Team.EntityLogicalName, Key);
            var config = new Config()
            {
                Id = Guid.NewGuid(),
                Name = Config.ConfigParameterKeys.Key,
                Value = Key.ToString()
            };

            context.Initialize(new List<Entity> { config, team });
            executionContext.InputParameters.Add(Plugin.Target, incident.ToEntityReference());
            executionContext.InputParameters.Add(Plugin.Assignee, assignee);
            executionContext.PreEntityImages.Add(Plugin.PreImage, incident);

            // Act
            context.ExecutePluginWith(executionContext, new Plugin());

            // Assert
            executionContext.InputParameters.TryGetValue(Plugin.Assignee, out var inputParameter);
            Assert.AreEqual(inputParameter, team.ToEntityReference());
        }

        [TestMethod()]
        public void Test2()
        {
            // setup 
            var context = new XrmFakedContext();
            var executionContext = context.GetDefaultPluginContext();
            var config = new Config()
            {
                Id = Guid.NewGuid(),
                Name = Config.ConfigParameterKeys.Key,
                Value = Key.ToString()
            };
            context.Initialize(new List<Entity>() {
                config
            });
            var assignee = new EntityReference(Team.EntityLogicalName, Key);
            var incidentId = Guid.NewGuid();
            var incident = new Entity(Incident.EntityLogicalName, incidentId)
            {
                [Incident.FieldNames.Id] = incidentId,
            };
            executionContext.PreEntityImages.Add(Plugin.PreImage, incident);
            executionContext.InputParameters.Add(Plugin.Assignee, assignee);
            executionContext.InputParameters.Add(Plugin.Target, incident.ToEntityReference());

            // Act
            context.ExecutePluginWith(executionContext, new Plugin());

            // Assert
            executionContext.InputParameters.TryGetValue(Plugin.Assignee, out var inputParameter);
            Assert.AreEqual(inputParameter, assignee);
        }

        [TestMethod()]
        public void Test3()
        {
            // setup 
            var context = new XrmFakedContext();
            var executionContext = context.GetDefaultPluginContext();
            var customRef = new EntityReference(Custom.EntityLogicalName, Guid.NewGuid());
            var teamId = Guid.NewGuid();
            var team = new Entity(Team.EntityLogicalName, teamId)
            {
                [Team.FieldNames.Id] = teamId,
                [Team.FieldNames.CustomFieldId] = customRef,
                [Team.FieldNames.IsDefault] = true
            };
            var incidentId = Guid.NewGuid();
            var incident = new Entity(Incident.EntityLogicalName, incidentId)
            {
                [Incident.FieldNames.Id] = incidentId,
                [Incident.FieldNames.CustomFieldId] = customRef,
            };
            var assignee = new EntityReference(Team.EntityLogicalName, Guid.NewGuid());
            var config = new Config()
            {
                Id = Guid.NewGuid(),
                Name = Config.ConfigParameterKeys.Key,
                Value = Key.ToString()
            };

            context.Initialize(new List<Entity> { config, team });
            executionContext.InputParameters.Add(Plugin.Target, incident.ToEntityReference());
            executionContext.InputParameters.Add(Plugin.Assignee, assignee);
            executionContext.PreEntityImages.Add(Plugin.PreImage, incident);

            // Act
            context.ExecutePluginWith(executionContext, new Plugin());

            // Assert
            executionContext.InputParameters.TryGetValue(Plugin.Assignee, out var inputParameter);
            Assert.AreEqual(inputParameter, assignee);
        }

        [TestMethod()]
        public void Test4()
        {
            // setup 
            var context = new XrmFakedContext();
            var executionContext = context.GetDefaultPluginContext();
            var customRef = new EntityReference(Custom.EntityLogicalName, Guid.NewGuid());
            var teamId = Guid.NewGuid();
            var team = new Entity(Team.EntityLogicalName, teamId)
            {
                [Team.FieldNames.Id] = teamId,
                [Team.FieldNames.CustomFieldId] = customRef,
                [Team.FieldNames.IsDefault] = true
            };
            var incidentId = Guid.NewGuid();
            var incident = new Entity(Incident.EntityLogicalName, incidentId)
            {
                [Incident.FieldNames.Id] = incidentId,
                [Incident.FieldNames.CustomFieldId] = customRef,
            };
            var assignee = new EntityReference(SystemUser, Key);
            var config = new Config()
            {
                Id = Guid.NewGuid(),
                Name = Config.ConfigParameterKeys.Key,
                Value = Key.ToString()
            };

            context.Initialize(new List<Entity> { config, team });
            executionContext.InputParameters.Add(Plugin.Target, incident.ToEntityReference());
            executionContext.InputParameters.Add(Plugin.Assignee, assignee);
            executionContext.PreEntityImages.Add(Plugin.PreImage, incident);

            // Act
            context.ExecutePluginWith(executionContext, new Plugin());

            // Assert
            executionContext.InputParameters.TryGetValue(Plugin.Assignee, out var inputParameter);
            Assert.AreEqual(inputParameter, assignee);
        }

        [TestMethod()]
        public void Test5()
        {
            // setup 
            var context = new XrmFakedContext();
            var executionContext = context.GetDefaultPluginContext();
            var customRef = new EntityReference(Custom.EntityLogicalName, Guid.NewGuid());
            var teamId = Guid.NewGuid();
            var team = new Entity(Team.EntityLogicalName, teamId)
            {
                [Team.FieldNames.Id] = teamId,
                [Team.FieldNames.CustomFieldId] = customRef,
                [Team.FieldNames.IsDefault] = true
            };
            var incidentId = Guid.NewGuid();
            var incident = new Entity(Incident.EntityLogicalName, incidentId)
            {
                [Incident.FieldNames.Id] = incidentId,
                [Incident.FieldNames.CustomFieldId] = customRef,
            };
            var assignee = new EntityReference(SystemUser, Key);

            context.Initialize(new List<Entity> { team });
            executionContext.InputParameters.Add(Plugin.Target, incident.ToEntityReference());
            executionContext.InputParameters.Add(Plugin.Assignee, assignee);
            executionContext.PreEntityImages.Add(Plugin.PreImage, incident);

            // Act
            context.ExecutePluginWith(executionContext, new Plugin());

            // Assert
            executionContext.InputParameters.TryGetValue(Plugin.Assignee, out var inputParameter);
            Assert.AreEqual(inputParameter, assignee);
        }

        [TestMethod()]
        public void Test6()
        {
            // setup 
            var context = new XrmFakedContext();
            var executionContext = context.GetDefaultPluginContext();
            var customRef = new EntityReference(Custom.EntityLogicalName, Guid.NewGuid());
            var incidentId = Guid.NewGuid();
            var incident = new Entity(Incident.EntityLogicalName, incidentId)
            {
                [Incident.FieldNames.Id] = incidentId,
                [Incident.FieldNames.CustomFieldId] = customRef,
            };
            var config = new Config()
            {
                Id = Guid.NewGuid(),
                Name = Config.ConfigParameterKeys.Key,
                Value = Key.ToString()
            };
            var assignee = new EntityReference(Team.EntityLogicalName, Key);
            context.Initialize(new List<Entity> { config });
            executionContext.InputParameters.Add(Plugin.Target, incident.ToEntityReference());
            executionContext.InputParameters.Add(Plugin.Assignee, assignee);
            executionContext.PreEntityImages.Add(Plugin.PreImage, incident);

            // Act
            var error = Assert.ThrowsException<InvalidPluginExecutionException>(
                () => context.ExecutePluginWith(executionContext, new Plugin()));

            // Assert
            Assert.AreEqual(Plugin.NOT_FOUND_MESSAGE, error.Message);
        }
    }
}