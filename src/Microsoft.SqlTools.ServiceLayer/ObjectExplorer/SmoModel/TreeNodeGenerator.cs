using System;
using System.Collections.Generic;
using System.Composition;
using Microsoft.SqlTools.ServiceLayer;
using Microsoft.SqlTools.ServiceLayer.ObjectExplorer.Nodes;

namespace Microsoft.SqlTools.ServiceLayer.ObjectExplorer.SmoModel
{
	
    internal sealed partial class TableInstanceTreeNode : SmoTreeNode
    {
    	public TableInstanceTreeNode() : base()
    	{
    		NodeValue = string.Empty;
    		this.NodeType = "TableInstance";
    		this.NodeTypeId = NodeTypes.TableInstance;
	    	OnInitialize();
    	}
    }

    internal sealed partial class ViewInstanceTreeNode : SmoTreeNode
    {
    	public ViewInstanceTreeNode() : base()
    	{
    		NodeValue = string.Empty;
    		this.NodeType = "ViewInstance";
    		this.NodeTypeId = NodeTypes.ViewInstance;
	    	OnInitialize();
    	}
    }

    internal sealed partial class UserDefinedTableTypeInstanceTreeNode : SmoTreeNode
    {
    	public UserDefinedTableTypeInstanceTreeNode() : base()
    	{
    		NodeValue = string.Empty;
    		this.NodeType = "UserDefinedTableTypeInstance";
    		this.NodeTypeId = NodeTypes.UserDefinedTableTypeInstance;
	    	OnInitialize();
    	}
    }

    internal sealed partial class StoredProcedureInstanceTreeNode : SmoTreeNode
    {
    	public StoredProcedureInstanceTreeNode() : base()
    	{
    		NodeValue = string.Empty;
    		this.NodeType = "StoredProcedureInstance";
    		this.NodeTypeId = NodeTypes.StoredProcedureInstance;
	    	OnInitialize();
    	}
    }

    internal sealed partial class TableValuedFunctionInstanceTreeNode : SmoTreeNode
    {
    	public TableValuedFunctionInstanceTreeNode() : base()
    	{
    		NodeValue = string.Empty;
    		this.NodeType = "TableValuedFunctionInstance";
    		this.NodeTypeId = NodeTypes.TableValuedFunctionInstance;
	    	OnInitialize();
    	}
    }

    internal sealed partial class ScalarValuedFunctionInstanceTreeNode : SmoTreeNode
    {
    	public ScalarValuedFunctionInstanceTreeNode() : base()
    	{
    		NodeValue = string.Empty;
    		this.NodeType = "ScalarValuedFunctionInstance";
    		this.NodeTypeId = NodeTypes.ScalarValuedFunctionInstance;
	    	OnInitialize();
    	}
    }

    internal sealed partial class AggregateFunctionInstanceTreeNode : SmoTreeNode
    {
    	public AggregateFunctionInstanceTreeNode() : base()
    	{
    		NodeValue = string.Empty;
    		this.NodeType = "AggregateFunctionInstance";
    		this.NodeTypeId = NodeTypes.AggregateFunctionInstance;
	    	OnInitialize();
    	}
    }

    internal sealed partial class FileGroupInstanceTreeNode : SmoTreeNode
    {
    	public FileGroupInstanceTreeNode() : base()
    	{
    		NodeValue = string.Empty;
    		this.NodeType = "FileGroupInstance";
    		this.NodeTypeId = NodeTypes.FileGroupInstance;
	    	OnInitialize();
    	}
    }

    internal sealed partial class ExternalTableInstanceTreeNode : SmoTreeNode
    {
    	public ExternalTableInstanceTreeNode() : base()
    	{
    		NodeValue = string.Empty;
    		this.NodeType = "ExternalTableInstance";
    		this.NodeTypeId = NodeTypes.ExternalTableInstance;
	    	OnInitialize();
    	}
    }

    internal sealed partial class ExternalResourceInstanceTreeNode : SmoTreeNode
    {
    	public ExternalResourceInstanceTreeNode() : base()
    	{
    		NodeValue = string.Empty;
    		this.NodeType = "ExternalResourceInstance";
    		this.NodeTypeId = NodeTypes.ExternalResourceInstance;
	    	OnInitialize();
    	}
    }

    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class ServerInstanceChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "ServerInstance" }; }

        protected override void OnExpandPopulateFolders(IList<TreeNode> currentChildren, TreeNode parent)
        {
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_Databases,
                                                              NodeType = "Databases",
                                                              NodeTypeId = NodeTypes.Databases,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_Security,
                                                              NodeType = "ServerLevelSecurity",
                                                              NodeTypeId = NodeTypes.ServerLevelSecurity,
                                                              ValidFor = ValidForFlag.Sql2005|ValidForFlag.Sql2008|ValidForFlag.Sql2012|ValidForFlag.Sql2014|ValidForFlag.Sql2016|ValidForFlag.Azure|ValidForFlag.AzureV12|ValidForFlag.NotContainedUser|ValidForFlag.CanViewSecurity,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_ServerObjects,
                                                              NodeType = "ServerLevelServerObjects",
                                                              NodeTypeId = NodeTypes.ServerLevelServerObjects,
                                                              ValidFor = ValidForFlag.Sql2005|ValidForFlag.Sql2008|ValidForFlag.Sql2012|ValidForFlag.Sql2014|ValidForFlag.Sql2016|ValidForFlag.NotContainedUser,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class DatabasesChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "Databases" }; }


        protected override void OnExpandPopulateFolders(IList<TreeNode> currentChildren, TreeNode parent)
        {
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_SystemDatabases,
                                                              NodeType = "SystemDatabases",
                                                              NodeTypeId = NodeTypes.SystemDatabases,
                                                              ValidFor = ValidForFlag.Sql2005|ValidForFlag.Sql2008|ValidForFlag.Sql2012|ValidForFlag.Sql2014|ValidForFlag.Sql2016|ValidForFlag.Azure|ValidForFlag.AzureV12|ValidForFlag.NotContainedUser|ValidForFlag.CanConnectToMaster,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class ServerLevelSecurityChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "ServerLevelSecurity" }; }

        protected override void OnExpandPopulateFolders(IList<TreeNode> currentChildren, TreeNode parent)
        {
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_LinkedServerLogins,
                                                              NodeType = "ServerLevelLinkedServerLogins",
                                                              NodeTypeId = NodeTypes.ServerLevelLinkedServerLogins,
                                                              ValidFor = ValidForFlag.Sql2005|ValidForFlag.Sql2008|ValidForFlag.Sql2012|ValidForFlag.Sql2014|ValidForFlag.Sql2016,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_Logins,
                                                              NodeType = "ServerLevelLogins",
                                                              NodeTypeId = NodeTypes.ServerLevelLogins,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_ServerRoles,
                                                              NodeType = "ServerLevelServerRoles",
                                                              NodeTypeId = NodeTypes.ServerLevelServerRoles,
                                                              ValidFor = ValidForFlag.Sql2005|ValidForFlag.Sql2008|ValidForFlag.Sql2012|ValidForFlag.Sql2014|ValidForFlag.Sql2016,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_Credentials,
                                                              NodeType = "ServerLevelCredentials",
                                                              NodeTypeId = NodeTypes.ServerLevelCredentials,
                                                              ValidFor = ValidForFlag.Sql2005|ValidForFlag.Sql2008|ValidForFlag.Sql2012|ValidForFlag.Sql2014|ValidForFlag.Sql2016,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_CryptographicProviders,
                                                              NodeType = "ServerLevelCryptographicProviders",
                                                              NodeTypeId = NodeTypes.ServerLevelCryptographicProviders,
                                                              ValidFor = ValidForFlag.Sql2008|ValidForFlag.Sql2012|ValidForFlag.Sql2014|ValidForFlag.Sql2016|ValidForFlag.NotDebugInstance,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_ServerAudits,
                                                              NodeType = "ServerLevelServerAudits",
                                                              NodeTypeId = NodeTypes.ServerLevelServerAudits,
                                                              ValidFor = ValidForFlag.Sql2008|ValidForFlag.Sql2012|ValidForFlag.Sql2014|ValidForFlag.Sql2016,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_ServerAuditSpecifications,
                                                              NodeType = "ServerLevelServerAuditSpecifications",
                                                              NodeTypeId = NodeTypes.ServerLevelServerAuditSpecifications,
                                                              ValidFor = ValidForFlag.Sql2008|ValidForFlag.Sql2012|ValidForFlag.Sql2014|ValidForFlag.Sql2016,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
        }

        internal override Type[] TypesToReverse { get {return null;} }


        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            return null;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class ServerLevelServerObjectsChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "ServerLevelServerObjects" }; }

        protected override void OnExpandPopulateFolders(IList<TreeNode> currentChildren, TreeNode parent)
        {
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_Endpoints,
                                                              NodeType = "ServerLevelEndpoints",
                                                              NodeTypeId = NodeTypes.ServerLevelEndpoints,
                                                              ValidFor = ValidForFlag.Sql2005|ValidForFlag.Sql2008|ValidForFlag.Sql2012|ValidForFlag.Sql2014|ValidForFlag.Sql2016,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_LinkedServers,
                                                              NodeType = "ServerLevelLinkedServers",
                                                              NodeTypeId = NodeTypes.ServerLevelLinkedServers,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_ServerTriggers,
                                                              NodeType = "ServerLevelServerTriggers",
                                                              NodeTypeId = NodeTypes.ServerLevelServerTriggers,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_ErrorMessages,
                                                              NodeType = "ServerLevelErrorMessages",
                                                              NodeTypeId = NodeTypes.ServerLevelErrorMessages,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
        }

        internal override Type[] TypesToReverse { get {return null;} }


        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            return null;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class SystemDatabasesChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "SystemDatabases" }; }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class ServerLevelLinkedServerLoginsChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "ServerLevelLinkedServerLogins" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlLinkedServerLoginQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class ServerLevelLoginsChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "ServerLevelLogins" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlLoginQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class ServerLevelServerRolesChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "ServerLevelServerRoles" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlServerRoleQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class ServerLevelCredentialsChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "ServerLevelCredentials" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlCredentialQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class ServerLevelCryptographicProvidersChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "ServerLevelCryptographicProviders" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlCryptographicProviderQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class ServerLevelServerAuditsChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "ServerLevelServerAudits" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlServerAuditQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class ServerLevelServerAuditSpecificationsChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "ServerLevelServerAuditSpecifications" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlServerAuditSpecificationQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class ServerLevelEndpointsChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "ServerLevelEndpoints" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlEndpointQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class ServerLevelLinkedServersChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "ServerLevelLinkedServers" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlLinkedServerQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class ServerLevelServerTriggersChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "ServerLevelServerTriggers" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlServerDdlTriggerQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class ServerLevelErrorMessagesChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "ServerLevelErrorMessages" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlErrorMessageQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class DatabaseInstanceChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "DatabaseInstance" }; }


        protected override void OnExpandPopulateFolders(IList<TreeNode> currentChildren, TreeNode parent)
        {
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_Tables,
                                                              NodeType = "Tables",
                                                              NodeTypeId = NodeTypes.Tables,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_Views,
                                                              NodeType = "Views",
                                                              NodeTypeId = NodeTypes.Views,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_Synonyms,
                                                              NodeType = "Synonyms",
                                                              NodeTypeId = NodeTypes.Synonyms,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_Programmability,
                                                              NodeType = "Programmability",
                                                              NodeTypeId = NodeTypes.Programmability,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_ExternalResources,
                                                              NodeType = "ExternalResources",
                                                              NodeTypeId = NodeTypes.ExternalResources,
                                                              ValidFor = ValidForFlag.Sql2016|ValidForFlag.AzureV12,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_ServiceBroker,
                                                              NodeType = "ServiceBroker",
                                                              NodeTypeId = NodeTypes.ServiceBroker,
                                                              ValidFor = ValidForFlag.Sql2005|ValidForFlag.Sql2008|ValidForFlag.Sql2012|ValidForFlag.Sql2014|ValidForFlag.Sql2016,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_Storage,
                                                              NodeType = "Storage",
                                                              NodeTypeId = NodeTypes.Storage,
                                                              ValidFor = ValidForFlag.Sql2005|ValidForFlag.Sql2008|ValidForFlag.Sql2012|ValidForFlag.Sql2014|ValidForFlag.Sql2016|ValidForFlag.AzureV12,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_Security,
                                                              NodeType = "Security",
                                                              NodeTypeId = NodeTypes.Security,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
        }

        internal override Type[] TypesToReverse
        {
           get
           {
              return new Type[0];           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class TablesChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "Tables" }; }


        protected override void OnExpandPopulateFolders(IList<TreeNode> currentChildren, TreeNode parent)
        {
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_SystemTables,
                                                              NodeType = "SystemTables",
                                                              NodeTypeId = NodeTypes.SystemTables,
                                                              IsMsShippedOwned = true,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_FileTables,
                                                              NodeType = "FileTables",
                                                              NodeTypeId = NodeTypes.FileTables,
                                                              ValidFor = ValidForFlag.Sql2012|ValidForFlag.Sql2014|ValidForFlag.Sql2016|ValidForFlag.NotDebugInstance,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_ExternalTables,
                                                              NodeType = "ExternalTables",
                                                              NodeTypeId = NodeTypes.ExternalTables,
                                                              ValidFor = ValidForFlag.Sql2016|ValidForFlag.AzureV12,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
        }

        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlTableQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class ViewsChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "Views" }; }


        protected override void OnExpandPopulateFolders(IList<TreeNode> currentChildren, TreeNode parent)
        {
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_SystemViews,
                                                              NodeType = "SystemViews",
                                                              NodeTypeId = NodeTypes.SystemViews,
                                                              IsMsShippedOwned = true,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
        }

        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlViewQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class SynonymsChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "Synonyms" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlSynonymQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class ProgrammabilityChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "Programmability" }; }

        protected override void OnExpandPopulateFolders(IList<TreeNode> currentChildren, TreeNode parent)
        {
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_StoredProcedures,
                                                              NodeType = "StoredProcedures",
                                                              NodeTypeId = NodeTypes.StoredProcedures,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_Functions,
                                                              NodeType = "Functions",
                                                              NodeTypeId = NodeTypes.Functions,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_DatabaseTriggers,
                                                              NodeType = "DatabaseTriggers",
                                                              NodeTypeId = NodeTypes.DatabaseTriggers,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_Assemblies,
                                                              NodeType = "Assemblies",
                                                              NodeTypeId = NodeTypes.Assemblies,
                                                              ValidFor = ValidForFlag.Sql2005|ValidForFlag.Sql2008|ValidForFlag.Sql2012|ValidForFlag.Sql2014|ValidForFlag.Sql2016|ValidForFlag.AzureV12,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_Types,
                                                              NodeType = "Types",
                                                              NodeTypeId = NodeTypes.Types,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_Rules,
                                                              NodeType = "Rules",
                                                              NodeTypeId = NodeTypes.Rules,
                                                              ValidFor = ValidForFlag.Sql2005|ValidForFlag.Sql2008|ValidForFlag.Sql2012|ValidForFlag.Sql2014|ValidForFlag.Sql2016|ValidForFlag.AzureV12,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_Defaults,
                                                              NodeType = "Defaults",
                                                              NodeTypeId = NodeTypes.Defaults,
                                                              ValidFor = ValidForFlag.Sql2005|ValidForFlag.Sql2008|ValidForFlag.Sql2012|ValidForFlag.Sql2014|ValidForFlag.Sql2016|ValidForFlag.AzureV12,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_Sequences,
                                                              NodeType = "Sequences",
                                                              NodeTypeId = NodeTypes.Sequences,
                                                              ValidFor = ValidForFlag.Sql2012|ValidForFlag.Sql2014|ValidForFlag.Sql2016|ValidForFlag.AzureV12,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
        }

        internal override Type[] TypesToReverse { get {return null;} }


        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            return null;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class ExternalResourcesChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "ExternalResources" }; }

        protected override void OnExpandPopulateFolders(IList<TreeNode> currentChildren, TreeNode parent)
        {
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_ExternalDataSources,
                                                              NodeType = "ExternalDataSources",
                                                              NodeTypeId = NodeTypes.ExternalDataSources,
                                                              ValidFor = ValidForFlag.Sql2016|ValidForFlag.AzureV12,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_ExternalFileFormats,
                                                              NodeType = "ExternalFileFormats",
                                                              NodeTypeId = NodeTypes.ExternalFileFormats,
                                                              ValidFor = ValidForFlag.Sql2016,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
        }

        internal override Type[] TypesToReverse { get {return null;} }


        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            return null;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class ServiceBrokerChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "ServiceBroker" }; }

        protected override void OnExpandPopulateFolders(IList<TreeNode> currentChildren, TreeNode parent)
        {
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_MessageTypes,
                                                              NodeType = "MessageTypes",
                                                              NodeTypeId = NodeTypes.MessageTypes,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_Contracts,
                                                              NodeType = "Contracts",
                                                              NodeTypeId = NodeTypes.Contracts,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_Queues,
                                                              NodeType = "Queues",
                                                              NodeTypeId = NodeTypes.Queues,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_Services,
                                                              NodeType = "Services",
                                                              NodeTypeId = NodeTypes.Services,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_RemoteServiceBindings,
                                                              NodeType = "RemoteServiceBindings",
                                                              NodeTypeId = NodeTypes.RemoteServiceBindings,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_BrokerPriorities,
                                                              NodeType = "BrokerPriorities",
                                                              NodeTypeId = NodeTypes.BrokerPriorities,
                                                              ValidFor = ValidForFlag.Sql2008|ValidForFlag.Sql2012|ValidForFlag.Sql2014|ValidForFlag.Sql2016,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
        }

        internal override Type[] TypesToReverse { get {return null;} }


        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            return null;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class StorageChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "Storage" }; }

        protected override void OnExpandPopulateFolders(IList<TreeNode> currentChildren, TreeNode parent)
        {
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_FileGroups,
                                                              NodeType = "FileGroups",
                                                              NodeTypeId = NodeTypes.FileGroups,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_FullTextCatalogs,
                                                              NodeType = "FullTextCatalogs",
                                                              NodeTypeId = NodeTypes.FullTextCatalogs,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_FullTextStopLists,
                                                              NodeType = "FullTextStopLists",
                                                              NodeTypeId = NodeTypes.FullTextStopLists,
                                                              ValidFor = ValidForFlag.Sql2008|ValidForFlag.Sql2012|ValidForFlag.Sql2014|ValidForFlag.Sql2016|ValidForFlag.AzureV12,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_LogFiles,
                                                              NodeType = "SqlLogFiles",
                                                              NodeTypeId = NodeTypes.SqlLogFiles,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_PartitionFunctions,
                                                              NodeType = "PartitionFunctions",
                                                              NodeTypeId = NodeTypes.PartitionFunctions,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_PartitionSchemes,
                                                              NodeType = "PartitionSchemes",
                                                              NodeTypeId = NodeTypes.PartitionSchemes,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_SearchPropertyLists,
                                                              NodeType = "SearchPropertyLists",
                                                              NodeTypeId = NodeTypes.SearchPropertyLists,
                                                              ValidFor = ValidForFlag.Sql2012|ValidForFlag.Sql2014|ValidForFlag.Sql2016|ValidForFlag.AzureV12,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
        }

        internal override Type[] TypesToReverse { get {return null;} }


        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            return null;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class SecurityChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "Security" }; }

        protected override void OnExpandPopulateFolders(IList<TreeNode> currentChildren, TreeNode parent)
        {
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_Users,
                                                              NodeType = "Users",
                                                              NodeTypeId = NodeTypes.Users,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_Roles,
                                                              NodeType = "Roles",
                                                              NodeTypeId = NodeTypes.Roles,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_Schemas,
                                                              NodeType = "Schemas",
                                                              NodeTypeId = NodeTypes.Schemas,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_AsymmetricKeys,
                                                              NodeType = "AsymmetricKeys",
                                                              NodeTypeId = NodeTypes.AsymmetricKeys,
                                                              ValidFor = ValidForFlag.Sql2005|ValidForFlag.Sql2008|ValidForFlag.Sql2012|ValidForFlag.Sql2014|ValidForFlag.Sql2016,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_Certificates,
                                                              NodeType = "Certificates",
                                                              NodeTypeId = NodeTypes.Certificates,
                                                              ValidFor = ValidForFlag.Sql2005|ValidForFlag.Sql2008|ValidForFlag.Sql2012|ValidForFlag.Sql2014|ValidForFlag.Sql2016,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_SymmetricKeys,
                                                              NodeType = "SymmetricKeys",
                                                              NodeTypeId = NodeTypes.SymmetricKeys,
                                                              ValidFor = ValidForFlag.Sql2005|ValidForFlag.Sql2008|ValidForFlag.Sql2012|ValidForFlag.Sql2014|ValidForFlag.Sql2016,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_DatabaseScopedCredentials,
                                                              NodeType = "DatabaseScopedCredentials",
                                                              NodeTypeId = NodeTypes.DatabaseScopedCredentials,
                                                              ValidFor = ValidForFlag.Sql2016|ValidForFlag.AzureV12,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_DatabaseEncryptionKeys,
                                                              NodeType = "DatabaseEncryptionKeys",
                                                              NodeTypeId = NodeTypes.DatabaseEncryptionKeys,
                                                              ValidFor = ValidForFlag.Sql2008|ValidForFlag.Sql2012|ValidForFlag.Sql2014|ValidForFlag.Sql2016,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_MasterKeys,
                                                              NodeType = "MasterKeys",
                                                              NodeTypeId = NodeTypes.MasterKeys,
                                                              ValidFor = ValidForFlag.Sql2005|ValidForFlag.Sql2008|ValidForFlag.Sql2012|ValidForFlag.Sql2014|ValidForFlag.Sql2016,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_DatabaseAuditSpecifications,
                                                              NodeType = "DatabaseAuditSpecifications",
                                                              NodeTypeId = NodeTypes.DatabaseAuditSpecifications,
                                                              ValidFor = ValidForFlag.Sql2008|ValidForFlag.Sql2012|ValidForFlag.Sql2014|ValidForFlag.Sql2016,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_SecurityPolicies,
                                                              NodeType = "SecurityPolicies",
                                                              NodeTypeId = NodeTypes.SecurityPolicies,
                                                              ValidFor = ValidForFlag.Sql2016|ValidForFlag.AzureV12,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_AlwaysEncryptedKeys,
                                                              NodeType = "AlwaysEncryptedKeys",
                                                              NodeTypeId = NodeTypes.AlwaysEncryptedKeys,
                                                              ValidFor = ValidForFlag.Sql2016|ValidForFlag.AzureV12,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
        }

        internal override Type[] TypesToReverse { get {return null;} }


        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            return null;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class SystemTablesChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "SystemTables" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlTableQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class FileTablesChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "FileTables" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlTableQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class ExternalTablesChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "ExternalTables" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlTableQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class TableInstanceChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "TableInstance" }; }


        protected override void OnExpandPopulateFolders(IList<TreeNode> currentChildren, TreeNode parent)
        {
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_Columns,
                                                              NodeType = "Columns",
                                                              NodeTypeId = NodeTypes.Columns,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_Keys,
                                                              NodeType = "Keys",
                                                              NodeTypeId = NodeTypes.Keys,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_Constraints,
                                                              NodeType = "Constraints",
                                                              NodeTypeId = NodeTypes.Constraints,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_Triggers,
                                                              NodeType = "Triggers",
                                                              NodeTypeId = NodeTypes.Triggers,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_Indexes,
                                                              NodeType = "Indexes",
                                                              NodeTypeId = NodeTypes.Indexes,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_Statistics,
                                                              NodeType = "Statistics",
                                                              NodeTypeId = NodeTypes.Statistics,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
        }

        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlTableQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class HistoryTableInstanceChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "HistoryTableInstance" }; }


        protected override void OnExpandPopulateFolders(IList<TreeNode> currentChildren, TreeNode parent)
        {
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_Columns,
                                                              NodeType = "Columns",
                                                              NodeTypeId = NodeTypes.Columns,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_Indexes,
                                                              NodeType = "Indexes",
                                                              NodeTypeId = NodeTypes.Indexes,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_Statistics,
                                                              NodeType = "Statistics",
                                                              NodeTypeId = NodeTypes.Statistics,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
        }

        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlTableQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class ExternalTableInstanceChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "ExternalTableInstance" }; }


        protected override void OnExpandPopulateFolders(IList<TreeNode> currentChildren, TreeNode parent)
        {
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_Columns,
                                                              NodeType = "Columns",
                                                              NodeTypeId = NodeTypes.Columns,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_Statistics,
                                                              NodeType = "Statistics",
                                                              NodeTypeId = NodeTypes.Statistics,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
        }

        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlTableQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class ColumnsChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "Columns" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlColumnQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            child.SortPriority = SmoTreeNode.NextSortPriority;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class KeysChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "Keys" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlIndexQuerier), typeof(SqlForeignKeyConstraintQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class ConstraintsChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "Constraints" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlDefaultConstraintQuerier), typeof(SqlCheckQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class TriggersChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "Triggers" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlDmlTriggerQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class IndexesChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "Indexes" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlIndexQuerier), typeof(SqlFullTextIndexQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class StatisticsChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "Statistics" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlStatisticQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class SystemViewsChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "SystemViews" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlViewQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class ViewInstanceChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "ViewInstance" }; }


        protected override void OnExpandPopulateFolders(IList<TreeNode> currentChildren, TreeNode parent)
        {
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_Columns,
                                                              NodeType = "Columns",
                                                              NodeTypeId = NodeTypes.Columns,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_Triggers,
                                                              NodeType = "Triggers",
                                                              NodeTypeId = NodeTypes.Triggers,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_Indexes,
                                                              NodeType = "Indexes",
                                                              NodeTypeId = NodeTypes.Indexes,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_Statistics,
                                                              NodeType = "Statistics",
                                                              NodeTypeId = NodeTypes.Statistics,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
        }

        internal override Type[] TypesToReverse
        {
           get
           {
              return new Type[0];           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class FunctionsChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "Functions" }; }

        protected override void OnExpandPopulateFolders(IList<TreeNode> currentChildren, TreeNode parent)
        {
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_TableValuedFunctions,
                                                              NodeType = "TableValuedFunctions",
                                                              NodeTypeId = NodeTypes.TableValuedFunctions,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_ScalarValuedFunctions,
                                                              NodeType = "ScalarValuedFunctions",
                                                              NodeTypeId = NodeTypes.ScalarValuedFunctions,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_AggregateFunctions,
                                                              NodeType = "AggregateFunctions",
                                                              NodeTypeId = NodeTypes.AggregateFunctions,
                                                              ValidFor = ValidForFlag.Sql2005|ValidForFlag.Sql2008|ValidForFlag.Sql2012|ValidForFlag.Sql2014|ValidForFlag.Sql2016|ValidForFlag.AzureV12,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
        }

        internal override Type[] TypesToReverse { get {return null;} }


        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            return null;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class DatabaseTriggersChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "DatabaseTriggers" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlDatabaseDdlTriggerQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class AssembliesChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "Assemblies" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlAssemblyQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class TypesChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "Types" }; }

        protected override void OnExpandPopulateFolders(IList<TreeNode> currentChildren, TreeNode parent)
        {
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_SystemDataTypes,
                                                              NodeType = "SystemDataTypes",
                                                              NodeTypeId = NodeTypes.SystemDataTypes,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_UserDefinedDataTypes,
                                                              NodeType = "UserDefinedDataTypes",
                                                              NodeTypeId = NodeTypes.UserDefinedDataTypes,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_UserDefinedTableTypes,
                                                              NodeType = "UserDefinedTableTypes",
                                                              NodeTypeId = NodeTypes.UserDefinedTableTypes,
                                                              ValidFor = ValidForFlag.Sql2008|ValidForFlag.Sql2012|ValidForFlag.Sql2014|ValidForFlag.Sql2016|ValidForFlag.Azure|ValidForFlag.AzureV12,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_UserDefinedTypes,
                                                              NodeType = "UserDefinedTypes",
                                                              NodeTypeId = NodeTypes.UserDefinedTypes,
                                                              ValidFor = ValidForFlag.Sql2005|ValidForFlag.Sql2008|ValidForFlag.Sql2012|ValidForFlag.Sql2014|ValidForFlag.Sql2016|ValidForFlag.AzureV12,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_XMLSchemaCollections,
                                                              NodeType = "XmlSchemaCollections",
                                                              NodeTypeId = NodeTypes.XmlSchemaCollections,
                                                              ValidFor = ValidForFlag.Sql2005|ValidForFlag.Sql2008|ValidForFlag.Sql2012|ValidForFlag.Sql2014|ValidForFlag.Sql2016|ValidForFlag.AzureV12,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
        }

        internal override Type[] TypesToReverse { get {return null;} }


        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            return null;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class RulesChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "Rules" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlRuleQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class DefaultsChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "Defaults" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlDefaultQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class SequencesChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "Sequences" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlSequenceQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class SystemDataTypesChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "SystemDataTypes" }; }

        protected override void OnExpandPopulateFolders(IList<TreeNode> currentChildren, TreeNode parent)
        {
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_SystemExactNumerics,
                                                              NodeType = "SystemExactNumerics",
                                                              NodeTypeId = NodeTypes.SystemExactNumerics,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_SystemApproximateNumerics,
                                                              NodeType = "SystemApproximateNumerics",
                                                              NodeTypeId = NodeTypes.SystemApproximateNumerics,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_SystemDateAndTime,
                                                              NodeType = "SystemDateAndTimes",
                                                              NodeTypeId = NodeTypes.SystemDateAndTimes,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_SystemCharacterStrings,
                                                              NodeType = "SystemCharacterStrings",
                                                              NodeTypeId = NodeTypes.SystemCharacterStrings,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_SystemUnicodeCharacterStrings,
                                                              NodeType = "SystemUnicodeCharacterStrings",
                                                              NodeTypeId = NodeTypes.SystemUnicodeCharacterStrings,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_SystemBinaryStrings,
                                                              NodeType = "SystemBinaryStrings",
                                                              NodeTypeId = NodeTypes.SystemBinaryStrings,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_SystemOtherDataTypes,
                                                              NodeType = "SystemOtherDataTypes",
                                                              NodeTypeId = NodeTypes.SystemOtherDataTypes,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_SystemCLRDataTypes,
                                                              NodeType = "SystemClrDataTypes",
                                                              NodeTypeId = NodeTypes.SystemClrDataTypes,
                                                              ValidFor = ValidForFlag.Sql2005|ValidForFlag.Sql2008|ValidForFlag.Sql2012|ValidForFlag.Sql2014|ValidForFlag.Sql2016|ValidForFlag.Azure|ValidForFlag.AzureV12,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_SystemSpatialDataTypes,
                                                              NodeType = "SystemSpatialDataTypes",
                                                              NodeTypeId = NodeTypes.SystemSpatialDataTypes,
                                                              ValidFor = ValidForFlag.Sql2008|ValidForFlag.Sql2012|ValidForFlag.Sql2014|ValidForFlag.Sql2016|ValidForFlag.Azure|ValidForFlag.AzureV12,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
        }

        internal override Type[] TypesToReverse { get {return null;} }


        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            return null;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class UserDefinedDataTypesChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "UserDefinedDataTypes" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlUserDefinedDataTypeQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class UserDefinedTableTypesChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "UserDefinedTableTypes" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlUserDefinedTableTypeQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class UserDefinedTypesChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "UserDefinedTypes" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlUserDefinedTypeQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class XmlSchemaCollectionsChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "XmlSchemaCollections" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlXmlSchemaCollectionQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class UserDefinedTableTypeInstanceChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "UserDefinedTableTypeInstance" }; }


        protected override void OnExpandPopulateFolders(IList<TreeNode> currentChildren, TreeNode parent)
        {
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_Columns,
                                                              NodeType = "UserDefinedTableTypeColumns",
                                                              NodeTypeId = NodeTypes.UserDefinedTableTypeColumns,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_Keys,
                                                              NodeType = "UserDefinedTableTypeKeys",
                                                              NodeTypeId = NodeTypes.UserDefinedTableTypeKeys,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_Constraints,
                                                              NodeType = "UserDefinedTableTypeConstraints",
                                                              NodeTypeId = NodeTypes.UserDefinedTableTypeConstraints,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
        }

        internal override Type[] TypesToReverse
        {
           get
           {
              return new Type[0];           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class UserDefinedTableTypeColumnsChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "UserDefinedTableTypeColumns" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlColumnQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            child.SortPriority = SmoTreeNode.NextSortPriority;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class UserDefinedTableTypeKeysChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "UserDefinedTableTypeKeys" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlIndexQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class UserDefinedTableTypeConstraintsChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "UserDefinedTableTypeConstraints" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlDefaultConstraintQuerier), typeof(SqlCheckQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class SystemExactNumericsChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "SystemExactNumerics" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlBuiltInTypeQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class SystemApproximateNumericsChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "SystemApproximateNumerics" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlBuiltInTypeQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class SystemDateAndTimesChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "SystemDateAndTimes" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlBuiltInTypeQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class SystemCharacterStringsChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "SystemCharacterStrings" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlBuiltInTypeQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class SystemUnicodeCharacterStringsChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "SystemUnicodeCharacterStrings" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlBuiltInTypeQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class SystemBinaryStringsChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "SystemBinaryStrings" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlBuiltInTypeQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class SystemOtherDataTypesChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "SystemOtherDataTypes" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlBuiltInTypeQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class SystemClrDataTypesChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "SystemClrDataTypes" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlUserDefinedTypeQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class SystemSpatialDataTypesChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "SystemSpatialDataTypes" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlUserDefinedTypeQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class ExternalDataSourcesChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "ExternalDataSources" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlExternalDataSourceQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class ExternalFileFormatsChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "ExternalFileFormats" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlExternalFileFormatQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class StoredProceduresChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "StoredProcedures" }; }


        protected override void OnExpandPopulateFolders(IList<TreeNode> currentChildren, TreeNode parent)
        {
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_SystemStoredProcedures,
                                                              NodeType = "SystemStoredProcedures",
                                                              NodeTypeId = NodeTypes.SystemStoredProcedures,
                                                              IsMsShippedOwned = true,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
        }

        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlProcedureQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class SystemStoredProceduresChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "SystemStoredProcedures" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlProcedureQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class StoredProcedureInstanceChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "StoredProcedureInstance" }; }


        protected override void OnExpandPopulateFolders(IList<TreeNode> currentChildren, TreeNode parent)
        {
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_Parameters,
                                                              NodeType = "StoredProcedureParameters",
                                                              NodeTypeId = NodeTypes.StoredProcedureParameters,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
        }

        internal override Type[] TypesToReverse
        {
           get
           {
              return new Type[0];           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class StoredProcedureParametersChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "StoredProcedureParameters" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlSubroutineParameterQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            child.SortPriority = SmoTreeNode.NextSortPriority;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class TableValuedFunctionsChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "TableValuedFunctions" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlUserDefinedFunctionQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class TableValuedFunctionInstanceChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "TableValuedFunctionInstance" }; }


        protected override void OnExpandPopulateFolders(IList<TreeNode> currentChildren, TreeNode parent)
        {
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_Parameters,
                                                              NodeType = "TableValuedFunctionParameters",
                                                              NodeTypeId = NodeTypes.TableValuedFunctionParameters,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
        }

        internal override Type[] TypesToReverse
        {
           get
           {
              return new Type[0];           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class TableValuedFunctionParametersChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "TableValuedFunctionParameters" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlSubroutineParameterQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            child.SortPriority = SmoTreeNode.NextSortPriority;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class ScalarValuedFunctionsChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "ScalarValuedFunctions" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlUserDefinedFunctionQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class ScalarValuedFunctionInstanceChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "ScalarValuedFunctionInstance" }; }


        protected override void OnExpandPopulateFolders(IList<TreeNode> currentChildren, TreeNode parent)
        {
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_Parameters,
                                                              NodeType = "ScalarValuedFunctionParameters",
                                                              NodeTypeId = NodeTypes.ScalarValuedFunctionParameters,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
        }

        internal override Type[] TypesToReverse
        {
           get
           {
              return new Type[0];           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class ScalarValuedFunctionParametersChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "ScalarValuedFunctionParameters" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlSubroutineParameterQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            child.SortPriority = SmoTreeNode.NextSortPriority;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class AggregateFunctionsChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "AggregateFunctions" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlUserDefinedAggregateQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class AggregateFunctionInstanceChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "AggregateFunctionInstance" }; }


        protected override void OnExpandPopulateFolders(IList<TreeNode> currentChildren, TreeNode parent)
        {
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_Parameters,
                                                              NodeType = "AggregateFunctionParameters",
                                                              NodeTypeId = NodeTypes.AggregateFunctionParameters,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
        }

        internal override Type[] TypesToReverse
        {
           get
           {
              return new Type[0];           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class AggregateFunctionParametersChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "AggregateFunctionParameters" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlSubroutineParameterQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            child.SortPriority = SmoTreeNode.NextSortPriority;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class RemoteServiceBindingsChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "RemoteServiceBindings" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlRemoteServiceBindingQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class BrokerPrioritiesChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "BrokerPriorities" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlBrokerPriorityQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class FileGroupsChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "FileGroups" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlFileGroupQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class FullTextCatalogsChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "FullTextCatalogs" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlFullTextCatalogQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class FullTextStopListsChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "FullTextStopLists" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlFullTextStopListQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class SqlLogFilesChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "SqlLogFiles" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlFileQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class PartitionFunctionsChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "PartitionFunctions" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlPartitionFunctionQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class PartitionSchemesChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "PartitionSchemes" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlPartitionSchemeQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class SearchPropertyListsChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "SearchPropertyLists" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlSearchPropertyListQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class FileGroupInstanceChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "FileGroupInstance" }; }

        protected override void OnExpandPopulateFolders(IList<TreeNode> currentChildren, TreeNode parent)
        {
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_FilegroupFiles,
                                                              NodeType = "FileGroupFiles",
                                                              NodeTypeId = NodeTypes.FileGroupFiles,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
        }

        internal override Type[] TypesToReverse { get {return null;} }


        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            return null;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class FileGroupFilesChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "FileGroupFiles" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlFileQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class UsersChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "Users" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlUserQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class RolesChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "Roles" }; }

        protected override void OnExpandPopulateFolders(IList<TreeNode> currentChildren, TreeNode parent)
        {
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_DatabaseRoles,
                                                              NodeType = "DatabaseRoles",
                                                              NodeTypeId = NodeTypes.DatabaseRoles,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_ApplicationRoles,
                                                              NodeType = "ApplicationRoles",
                                                              NodeTypeId = NodeTypes.ApplicationRoles,
                                                              ValidFor = ValidForFlag.Sql2005|ValidForFlag.Sql2008|ValidForFlag.Sql2012|ValidForFlag.Sql2014|ValidForFlag.Sql2016|ValidForFlag.AzureV12,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
        }

        internal override Type[] TypesToReverse { get {return null;} }


        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            return null;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class SchemasChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "Schemas" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlSchemaQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class AsymmetricKeysChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "AsymmetricKeys" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlAsymmetricKeyQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class CertificatesChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "Certificates" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlCertificateQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class SymmetricKeysChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "SymmetricKeys" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlSymmetricKeyQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class DatabaseEncryptionKeysChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "DatabaseEncryptionKeys" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlDatabaseEncryptionKeyQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class MasterKeysChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "MasterKeys" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlMasterKeyQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class DatabaseAuditSpecificationsChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "DatabaseAuditSpecifications" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlDatabaseAuditSpecificationQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class SecurityPoliciesChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "SecurityPolicies" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlSecurityPolicyQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class DatabaseScopedCredentialsChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "DatabaseScopedCredentials" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlDatabaseCredentialQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class AlwaysEncryptedKeysChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "AlwaysEncryptedKeys" }; }

        protected override void OnExpandPopulateFolders(IList<TreeNode> currentChildren, TreeNode parent)
        {
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_ColumnMasterKeys,
                                                              NodeType = "ColumnMasterKeys",
                                                              NodeTypeId = NodeTypes.ColumnMasterKeys,
                                                              ValidFor = ValidForFlag.Sql2016|ValidForFlag.AzureV12,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_ColumnEncryptionKeys,
                                                              NodeType = "ColumnEncryptionKeys",
                                                              NodeTypeId = NodeTypes.ColumnEncryptionKeys,
                                                              ValidFor = ValidForFlag.Sql2016|ValidForFlag.AzureV12,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
        }

        internal override Type[] TypesToReverse { get {return null;} }


        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            return null;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class DatabaseRolesChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "DatabaseRoles" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlRoleQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class ApplicationRolesChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "ApplicationRoles" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlApplicationRoleQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class ColumnMasterKeysChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "ColumnMasterKeys" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlColumnMasterKeyQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class ColumnEncryptionKeysChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "ColumnEncryptionKeys" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlColumnEncryptionKeyQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class MessageTypesChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "MessageTypes" }; }


        protected override void OnExpandPopulateFolders(IList<TreeNode> currentChildren, TreeNode parent)
        {
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_SystemMessageTypes,
                                                              NodeType = "SystemMessageTypes",
                                                              NodeTypeId = NodeTypes.SystemMessageTypes,
                                                              IsMsShippedOwned = true,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
        }

        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlMessageTypeQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class SystemMessageTypesChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "SystemMessageTypes" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlMessageTypeQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class ContractsChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "Contracts" }; }


        protected override void OnExpandPopulateFolders(IList<TreeNode> currentChildren, TreeNode parent)
        {
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_SystemContracts,
                                                              NodeType = "SystemContracts",
                                                              NodeTypeId = NodeTypes.SystemContracts,
                                                              IsMsShippedOwned = true,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
        }

        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlContractQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class SystemContractsChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "SystemContracts" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlContractQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class QueuesChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "Queues" }; }


        protected override void OnExpandPopulateFolders(IList<TreeNode> currentChildren, TreeNode parent)
        {
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_SystemQueues,
                                                              NodeType = "SystemQueues",
                                                              NodeTypeId = NodeTypes.SystemQueues,
                                                              IsMsShippedOwned = true,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
        }

        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlQueueQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class SystemQueuesChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "SystemQueues" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlQueueQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class ServicesChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "Services" }; }


        protected override void OnExpandPopulateFolders(IList<TreeNode> currentChildren, TreeNode parent)
        {
            currentChildren.Add(new SmoTreeNode {
                                                              NodeValue = SR.SchemaHierarchy_SystemServices,
                                                              NodeType = "SystemServices",
                                                              NodeTypeId = NodeTypes.SystemServices,
                                                              IsMsShippedOwned = true,
                                                              SortPriority = SmoTreeNode.NextSortPriority,
                                                          });
        }

        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlServiceQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
    [Export(typeof(ChildFactory))]
    [Shared]
    internal partial class SystemServicesChildFactory : SmoChildFactoryBase
    {
        public override IEnumerable<string> ApplicableParents() { return new[] { "SystemServices" }; }


        internal override Type[] TypesToReverse
        {
           get
           {
              return new [] { typeof(SqlServiceQuerier), };
           }
        }

        public override TreeNode CreateChild(TreeNode parent, object context)
        {
            var child = new SmoTreeNode();
            child.IsAlwaysLeaf = true;
            InitializeChild(child, context);
            return child;
        }

    }
}

