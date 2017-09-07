/**
 * Copyright 2017 The Nakama Authors
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;

namespace Nakama
{
    internal class NSelf : INSelf
    {
        public string AvatarUrl { get; private set; }

        public long CreatedAt { get; private set; }

        public string CustomId { get; private set; }

        public IList<string> DeviceIds { get; private set; }

        public string Email { get; private set; }

        public string FacebookId { get; private set; }

        public string Fullname { get; private set; }

        public string GameCenterId { get; private set; }

        public string GoogleId { get; private set; }

        public string Handle { get; private set; }

        public byte[] Id { get; private set; }

        public string Lang { get; private set; }

        public long LastOnlineAt { get; private set; }

        public string Location { get; private set; }

        public byte[] Metadata { get; private set; }

        public string SteamId { get; private set; }

        public string Timezone { get; private set; }

        public long UpdatedAt { get; private set; }

        public bool Verified { get; private set; }

        internal NSelf(Self message)
        {
            AvatarUrl = message.User.AvatarUrl;
            CreatedAt = message.User.CreatedAt;
            CustomId = message.CustomId;
            DeviceIds = message.DeviceIds;
            Email = message.Email;
            FacebookId = message.FacebookId;
            Fullname = message.User.Fullname;
            GameCenterId = message.GamecenterId;
            GoogleId = message.GoogleId;
            Handle = message.User.Handle;
            Id = message.User.Id.ToByteArray();
            Lang = message.User.Lang;
            LastOnlineAt = message.User.LastOnlineAt;
            Location = message.User.Location;
            Metadata = message.User.Metadata.ToByteArray();
            SteamId = message.SteamId;
            Timezone = message.User.Timezone;
            UpdatedAt = message.User.UpdatedAt;
            Verified = message.Verified;
        }

        public int CompareTo(INUser other)
        {
            if (other == null)
            {
                return 1;
            }

            for (int i = 0, l = Id.Length; i < l; i++)
            {
                if (Id[i] != other.Id[i])
                {
                    return -1;
                }
            }

            return 0;
        }

        public static bool operator >(NSelf self, NSelf other)
        {
            return self.CompareTo(other) == 1;
        }

        public static bool operator <(NSelf self, NSelf other)
        {
            return self.CompareTo(other) == -1;
        }

        public static bool operator >=(NSelf self, NSelf other)
        {
            return self.CompareTo(other) >= 0;
        }

        public static bool operator <=(NSelf self, NSelf other)
        {
            return self.CompareTo(other) <= 0;
        }

        public bool Equals(INUser other)
        {
            return CompareTo(other) == 0;
        }

        public override string ToString()
        {
            const string f = "NSelf(AvatarUrl={0},CreatedAt={1},CustomId={2},DeviceIds={3},Email={4},FacebookId={5}," +
                             "Fullname={6},GameCenterId={7},GoogleId={8},Handle={9},Id={10},Lang={11},LastOnlineAt={12}," +
                             "Location={13},Metadata={14},SteamId={15},Timezone={16},UpdatedAt={17},Verified={18})";
            return string.Format(f, AvatarUrl, CreatedAt, CustomId, DeviceIds, Email, FacebookId,
                Fullname, GameCenterId, GoogleId, Handle, Id, Lang, LastOnlineAt, Location,
                Metadata, SteamId, Timezone, UpdatedAt, Verified);
        }
    }
}