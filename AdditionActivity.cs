using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System.Activities;

namespace CDS.CustomActivities
{
    /// <summary>
    /// This Custom Activity can be used to add to numbers to each other.
    /// </summary>
    public sealed class AdditionActivity : CodeActivity
    {
        #region Arguments

        [Input("Operand A")]
        public InArgument<int> OperandA { get; set; }

        [Input("Operand B")]
        public InArgument<int> OperandB { get; set; }

        [Output("Result")]
        public OutArgument<int> Result { get; set; }

        #endregion Arguments

        #region Activity Logic

        protected override void Execute(CodeActivityContext executionContext)
        {
            ITracingService tracingService = executionContext.GetExtension<ITracingService>();

            int a = OperandA.Get<int>(executionContext);
            int b = OperandB.Get<int>(executionContext);

            tracingService.Trace($"Adding '{a}' to '{b}'.");

            Result.Set(executionContext, a + b);

            tracingService.Trace($"Result set to '{a + b}'.");
        }

        #endregion Activity Logic
    }
}
