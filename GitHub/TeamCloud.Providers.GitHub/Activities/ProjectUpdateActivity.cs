/**
 *  Copyright (c) Microsoft Corporation.
 *  Licensed under the MIT License.
 */

using System;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;
using TeamCloud.Model;
using TeamCloud.Model.Commands;
using TeamCloud.Serialization;

namespace TeamCloud.Providers.GitHub.Activities
{
    public static class ProjectUpdateActivity
    {
        [FunctionName(nameof(ProjectUpdateActivity))]
        public static Dictionary<string, string> RunActivity(
            [ActivityTrigger] ProviderProjectUpdateCommand command,
            ILogger log)
        {
            if (command is null)
                throw new ArgumentNullException(nameof(command));

            using (log.BeginCommandScope(command))
            {
                try
                {
                    return new Dictionary<string, string>();
                }
                catch (Exception exc)
                {
                    log.LogError(exc, $"{nameof(ProviderProjectUpdateCommand)} failed: {exc.Message}");

                    throw exc.AsSerializable();
                }
            }
        }
    }
}
