using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public class AccountData
    {
        public IsEarly is_early { get; set; }
        public DiscordMember discord_member { get; set; }
        public EnableDeveloperTools enable_developer_tools { get; set; }
        public IsStaff is_staff { get; set; }
    }
}
