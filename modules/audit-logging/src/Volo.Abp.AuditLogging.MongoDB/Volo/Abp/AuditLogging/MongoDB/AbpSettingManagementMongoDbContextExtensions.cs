﻿using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.MongoDB;

namespace Volo.Abp.AuditLogging.MongoDB
{
    public static class AbpSettingManagementMongoDbContextExtensions
    {
        public static void ConfigureSettingManagement(
            this IMongoModelBuilder builder,
            Action<MongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new AuditLoggingMongoModelBuilderConfigurationOptions();

            optionsAction?.Invoke(options);

            builder.Entity<AuditLog>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Settings";
            });
        }
    }
}
