using System;
using System.Collections.Generic;
using System.Text;

namespace StarUML_Keyfilemaker
{
    public class LicenseType
    {

        private static readonly List<LicenseType> _all = new List<LicenseType>();

        public static IReadOnlyList<LicenseType> All => _all.AsReadOnly();

        public static readonly LicenseType STANDARD = new LicenseType("STD", "Standard Edition");
        public static readonly LicenseType PROFESSIONAL = new LicenseType("PRO", "Professional Edition");
        public static readonly LicenseType COMMERCIAL = new LicenseType("CO", "Commercial Edition");
        public static readonly LicenseType EDUCATIONAL = new LicenseType("ED", "Educational Edition");
        public static readonly LicenseType PERSONAL = new LicenseType("PS", "Personal Edition");
        public static readonly LicenseType CLASSROOM = new LicenseType("CR", "Classroom Edition");
        public static readonly LicenseType CAMPUS = new LicenseType("CAMPUS", "Campus Edition");
        public static readonly LicenseType SITE = new LicenseType("SITE", "Site Edition");

        public string Code { get; }
        public string Description { get; }

        private LicenseType(string code, string description)
        {
            Code = code;
            Description = description;
            _all.Add(this);
        }

        public static LicenseType GetByCode(string code)
        {
            foreach (LicenseType licenseType in _all)
            {
                if (licenseType.Code.Equals(code, StringComparison.OrdinalIgnoreCase))
                {
                    return licenseType;
                }
            }
            return null;
        }
    }
}
