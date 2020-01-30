﻿/**
 *  Copyright (c) Microsoft Corporation.
 *  Licensed under the MIT License.
 */

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;
using TeamCloud.Model.Commands;
using TeamCloud.Providers.Azure.DevTestLabs.Activities;

namespace TeamCloud.Providers.Azure.DevTestLabs.Orchestrations
{
    public static class ProjectDeleteOrchestration
    {
        [FunctionName(nameof(ProjectDeleteOrchestration))]
        public static async Task RunOrchestration(
            [OrchestrationTrigger] IDurableOrchestrationContext functionContext,
            ILogger log)
        {
            if (functionContext is null)
                throw new ArgumentNullException(nameof(functionContext));

            var providerCommand = functionContext.GetInput<ProviderCommand>();

            var providerVariables = await functionContext
                .CallActivityAsync<Dictionary<string, string>>(nameof(ProjectDeleteActivity), providerCommand.Command)
                .ConfigureAwait(true);

            functionContext.SetOutput(providerVariables);

            functionContext.StartNewOrchestration(nameof(SendCommandResultOrchestration), providerCommand);
        }
    }
}
