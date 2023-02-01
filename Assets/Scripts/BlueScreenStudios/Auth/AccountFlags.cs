using System;

namespace BlueScreenStudios.Auth
{
    public class DiscordMember
    {
        public string Value { get; set; }
        public DateTime LastUpdated { get; set; }
        public string Permission { get; set; }
    }

    public class EnableDeveloperTools
    {
        public string Value { get; set; }
        public DateTime LastUpdated { get; set; }
        public string Permission { get; set; }
    }

    public class IsEarly
    {
        public string Value { get; set; }
        public DateTime LastUpdated { get; set; }
        public string Permission { get; set; }
    }

    public class IsStaff
    {
        public string Value { get; set; }
        public DateTime LastUpdated { get; set; }
        public string Permission { get; set; }
    }

    public class AccountFlagsData
    {
        public IsEarly is_early { get; set; }
        public DiscordMember discord_member { get; set; }
        public EnableDeveloperTools enable_developer_tools { get; set; }
        public IsStaff is_staff { get; set; }
    }

    public static class AccountFlags
    {
        /// <summary>
        /// Checks if the Discord Flag has been raised and set
        /// </summary>
        /// <param name="flags">The flag data to use when checking</param>
        /// <returns>True if the 'discord_member' flag has been raised and set on the server</returns>
        public static bool DiscordFlagEnabled(AccountFlagsData flags)
        {
            if(flags == null) return false;
            return flags.discord_member.Value == "true";
        }


        /// <summary>
        /// Checks if the Developer Flag has been raised and set
        /// </summary>
        /// <param name="flags">The flag data to use when checking</param>
        /// <returns>True if the 'enable_develoepr_tools' flag has been raised and set on the server</returns>
        public static bool DeveloperFlagEnabled(AccountFlagsData flags) 
        {
            if(flags == null) return false;
            return flags.enable_developer_tools.Value == "true";
        }

        /// <summary>
        /// Checks if the Early Flag has been raised and set
        /// </summary>
        /// <param name="flags">The flag data to use when checking</param>
        /// <returns>True if the 'is_early' flag has been raised and set on the server</returns>

        public static bool EarlyFlagEnabled(AccountFlagsData flags)
        {
            if(flags == null) return false;
            return flags.is_early.Value == "true";
        }

        /// <summary>
        /// Checks if the Staff Flag has been raised and set
        /// </summary>
        /// <param name="flags">The flag data to use when checking</param>
        /// <returns>True if the 'is_staff' flag has been raised and set on the server</returns>

        public static bool StaffFlagEnabled(AccountFlagsData flags)
        {
            if(flags == null) return false;
            return flags.is_staff.Value == "true";
        }
    }
}
