using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Workflow;
using Microsoft.SharePoint.WorkflowActions;

namespace SampleWorkflow.Workflow1
{
    public sealed partial class Workflow1 : SequentialWorkflowActivity
    {
        public Workflow1()
        {
            InitializeComponent();
        }

        public Guid workflowId = default(System.Guid);
        public SPWorkflowActivationProperties workflowProperties = new SPWorkflowActivationProperties();
        private void onWorkflowActivated1_Invoked(object sender, ExternalDataEventArgs e)
        {

        }
        private void RequireApproval(object sender, ConditionalEventArgs e)
        {
            try
            {
                string level = workflowProperties.Item["Approval Status"].ToString();
                if (level == "Level 0")
                {
                    e.Result = false;
                }
                else
                {
                    e.Result = true;
                }
            }
            catch
            {
            }
        }

        private void CheckEmployeementHistory(object sender, ConditionalEventArgs e)
        {
            string sEmpHistory = "";
            sEmpHistory = workflowProperties.Item["Employment History"].ToString();
            if (sEmpHistory.Trim().ToLower() == "good")
                e.Result = true;


        }
        private void CheckEmployeementBadHistory(object sender, ConditionalEventArgs e)
        {
            string sEmpHistory = "";
            sEmpHistory = workflowProperties.Item["Employment History"].ToString();
            if (sEmpHistory.Trim().ToLower() == "bad")
                e.Result = true;


        }
    }
}
