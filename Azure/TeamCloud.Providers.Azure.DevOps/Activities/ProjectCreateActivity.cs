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

namespace TeamCloud.Providers.Azure.DevOps.Activities
{
    public static class ProjectCreateActivity
    {
        [FunctionName(nameof(ProjectCreateActivity))]
        public static async Task<Dictionary<string, string>> RunActivity(
            [ActivityTrigger] ProviderProjectCreateCommand command,
            ILogger log)
        {
            if (command is null)
                throw new ArgumentNullException(nameof(command));

            await Task.Delay(30 * 1000);

            return new Dictionary<string, string> {
                { "LastCommandId", command.CommandId.ToString() }
            };
        }
    }
}
