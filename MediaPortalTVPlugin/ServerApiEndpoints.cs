﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

using MediaBrowser.Model.Services;
using MediaBrowser.Plugins.MediaPortal.Services.Entities;
using MediaBrowser.Plugins.MediaPortal.Services.Exceptions;
using MediaBrowser.Plugins.MediaPortal.Entities;

namespace MediaBrowser.Plugins.MediaPortal
{
    [Route("/MediaPortalPlugin/Profiles", "GET", Summary = "Gets a list of streaming profiles")]
    public class GetProfiles : IReturn<List<String>>
    {
    }

    [Route("/MediaPortalPlugin/ChannelGroups", "GET", Summary = "Gets a list of channel groups")]
    public class GetChannelGroups : IReturn<List<ChannelGroup>>
    {
    }

    [Route("/MediaPortalPlugin/ChannelSortOptions", "GET", Summary = "Gets a list of channel sort ordering")]
    public class GetChannelSortOptions : IReturn<List<ChannelSortOption>>
    {
    }

    [Route("/MediaPortalPlugin/TestConnection", "GET", Summary = "Tests the connection to MP Extended")]
    public class GetConnection : IReturn<Boolean>
    {
    }

    public class ServerApiEndpoints : IService
    {
        public object Get(GetProfiles request)
        {
            var profiles = new List<string>();
            try
            {
                profiles = Plugin.StreamingProxy.GetTranscoderProfiles(new CancellationToken()).Select(p => p.Name).ToList();
            }
            catch (ServiceAuthenticationException)
            {
                // Do nothing, allow an empty list to be passed out
            }
            catch (Exception exception)
            {
                Plugin.Logger.ErrorException("There was an issue retrieving transcoding profiles", exception);
            }

            return profiles;
        }

        public object Get(GetChannelGroups request)
        {
            var channelGroups = new List<ChannelGroup>();
            try
            {
                channelGroups = Plugin.TvProxy.GetChannelGroups(new CancellationToken());
            }
            catch (ServiceAuthenticationException)
            {
                // Do nothing, allow an empty list to be passed out
            }
            catch (Exception exception)
            {
                Plugin.Logger.ErrorException("There was an issue retrieving channel groups", exception);
            }

            return channelGroups;
        }

        public object Get(GetChannelSortOptions request)
        {
            var options = new List<ChannelSortOption>() 
            {
                new ChannelSortOption() { Id = ChannelSorting.Default.ToString(), Description = "Default" }, 
                new ChannelSortOption() { Id = ChannelSorting.ChannelId.ToString(), Description = "Channel Id" }, 
                new ChannelSortOption() { Id = ChannelSorting.ChannelName.ToString(), Description = "Channel Name" }, 
            };

            return options;
        }

        public object Get(GetConnection request)
        {
            try
            {
                var result = Plugin.TvProxy.GetStatusInfo(new CancellationToken());
                return true;
            }
            catch (ServiceAuthenticationException)
            {
                // Do nothing, allow an empty list to be passed out
            }
            catch (Exception exception)
            {
                Plugin.Logger.ErrorException("There was an issue testing the API connection", exception);
            }

            return false;
        }
    }
}
