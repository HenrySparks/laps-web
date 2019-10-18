﻿using System;
using System.DirectoryServices;
using System.Security.Principal;
using Lithnet.Laps.Web.Models;

namespace Lithnet.Laps.Web.Directory
{
    public sealed class ActiveDirectoryGroup: IGroup
    {
        private SearchResult groupPrincipal;

        internal static string[] PropertiesToGet = new string[] { "samAccountName", "distinguishedName", "tokenGroups", "displayName", "objectGuid", "objectSid", "samAccountName" };

        public ActiveDirectoryGroup(SearchResult groupPrincipal)
        {
            this.groupPrincipal = groupPrincipal;
        }

        public Guid? Guid => this.groupPrincipal.GetPropertyGuid("objectGuid");

        public SecurityIdentifier Sid => this.groupPrincipal.GetPropertySid("objectSid");

        public string SamAccountName => this.groupPrincipal.GetPropertyString("samAccountName");

        public string DistinguishedName => this.groupPrincipal.GetPropertyString("distinguishedName");
    }
}
