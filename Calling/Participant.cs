﻿using System.Threading.Tasks;
using Sinch.ServerSdk.Calling.Models;

namespace Sinch.ServerSdk.Calling
{
    public interface IParticipant
    {
        Task Mute();
        Task Unmute();
        Task Kick();
    }

    class Participant : IParticipant
    {
        private readonly IConferenceApiEndpoints _api;
        private readonly string _conferenceId;
        private readonly string _id;

        public Participant(IConferenceApiEndpoints api, string conferenceId, string id)
        {
            _api = api;
            _conferenceId = conferenceId;
            _id = id;
        }

        public Task Mute()
        {
            return _api.UpdateConference(_conferenceId, _id, new ConferenceCommand { Command = "mute" });
        }

        public Task Unmute()
        {
            return _api.UpdateConference(_conferenceId, _id, new ConferenceCommand { Command = "unmute" });
        }

        public Task Kick()
        {
            return _api.KickParticipant(_conferenceId, _id);
        }
    }
}