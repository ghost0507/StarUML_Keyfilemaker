using System;
using System.Collections.Generic;

namespace StarUML_Keyfilemaker
{
    public class LicenseVersion
    {

        private static readonly List<LicenseVersion> _all = new List<LicenseVersion>();
        public static IReadOnlyList<LicenseVersion> All => _all.AsReadOnly();

        //For v5.x, v6.x located in 'config.product_id' field of the 'package.json' file from '/resources/app.asar'
        //For v7.x located in 'src/utils/license-client.js' file from '/resources/app.asar'
        //For v5.x, v6.x located in 'SK' variable of the '/src/engine/license-manager.js' file from '/resources/app.asar'
        //For v7.x located in 'LICENSE_CRYPTO_KEY' variable of the '/src/utils/license-client.js' file from '/resources/app.asar'
        public static readonly LicenseVersion V5 = new LicenseVersion("STARUML.V5", "StarUML V5", "DF9B72CC966FBE3A46F99858C5AEE", @"license.key");
        public static readonly LicenseVersion V6 = new LicenseVersion("STARUML.V6", "StarUML V6", "DF9B72CC966FBE3A46F99858C5AEE", @"license.key");
        public static readonly LicenseVersion V7 = new LicenseVersion("STARUML.V7", "StarUML V7", "y0JMc9mvB1uvIi82GhdMJQXzVJxl+1Lc0RqZqWaQvx0=", @"activation.key");

        public string Code { get; }
        public string Description { get; }

        public string CryptoKey { get; }

        public string LicenseFilename { get; }

        private LicenseVersion(string code, string description, string cryptoKey, string licenseFilename)
        {
            Code = code;
            Description = description;
            CryptoKey = cryptoKey;
            LicenseFilename = licenseFilename;
            _all.Add(this);
        }

        public static LicenseVersion GetByCode(string code)
        {
            foreach (LicenseVersion licenseVersion in _all)
            {
                if (licenseVersion.Code.Equals(code, StringComparison.OrdinalIgnoreCase))
                {
                    return licenseVersion;
                }
            }
            return null;
        }
    }
}
