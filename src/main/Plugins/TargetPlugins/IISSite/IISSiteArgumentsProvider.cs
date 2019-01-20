﻿using Fclp;
using PKISharp.WACS.Configuration;

namespace PKISharp.WACS.Plugins.TargetPlugins
{
    class IISSiteArgumentsProvider : BaseArgumentsProvider<IISSiteArguments>
    {
        public override string Name => "IISSite(s)";
        public override string Group => "Target";
        public override string Condition => "--target iissite|iissites";
        public override bool Active(IISSiteArguments current)
        {
            return !string.IsNullOrEmpty(current.SiteId) ||
                !string.IsNullOrEmpty(current.CommonName) ||
                !string.IsNullOrEmpty(current.ExcludeBindings);
        }

        public override void Configure(FluentCommandLineParser<IISSiteArguments> parser)
        {
            parser.Setup(o => o.SiteId)
                .As("siteid")
                .WithDescription("Specify identifier of the site that the plugin should create the target from. For iissites this may be a comma separated list.");
            parser.Setup(o => o.CommonName)
                .As("commonname")
                .WithDescription("Specify the common name of the certificate that should be requested for the target.");
            parser.Setup(o => o.ExcludeBindings)
                .As("excludebindings")
                .WithDescription("Exclude bindings from the certificate. This may be a comma separated list.");
        }
    }
}
