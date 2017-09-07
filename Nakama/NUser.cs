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

namespace Nakama
{
    internal class NUser : INUser
    {
        public string AvatarUrl { get; private set; }

        public long CreatedAt { get; private set; }

        public string Fullname { get; private set; }

        public string Handle { get; private set; }

        public byte[] Id { get; private set; }

        public string Lang { get; private set; }

        public long LastOnlineAt { get; private set; }

        public string Location { get; private set; }

        public byte[] Metadata { get; private set; }

        public string Timezone { get; private set; }

        public long UpdatedAt { get; private set; }

        internal NUser(User message)
        {
            AvatarUrl = message.AvatarUrl;
            CreatedAt = message.CreatedAt;
            Fullname = message.Fullname;
            Handle = message.Handle;
            Id = message.Id.ToByteArray();
            Lang = message.Lang;
            LastOnlineAt = message.LastOnlineAt;
            Location = message.Location;
            Metadata = message.Metadata.ToByteArray();
            Timezone = message.Timezone;
            UpdatedAt = message.UpdatedAt;
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

        public static bool operator >(NUser self, NUser other)
        {
            return self.CompareTo(other) == 1;
        }

        public static bool operator <(NUser self, NUser other)
        {
            return self.CompareTo(other) == -1;
        }

        public static bool operator >=(NUser self, NUser other)
        {
            return self.CompareTo(other) >= 0;
        }

        public static bool operator <=(NUser self, NUser other)
        {
            return self.CompareTo(other) <= 0;
        }

        public bool Equals(INUser other)
        {
            return CompareTo(other) == 0;
        }

        public override string ToString()
        {
            const string f = "NUser(AvatarUrl={0},CreatedAt={1},Fullname={2},Handle={3},Id={4},Lang={5}," +
                             "LastOnlineAt={6},Location={7},Metadata={8},Timezone={9},UpdatedAt={10})";
            return string.Format(f, AvatarUrl, CreatedAt, Fullname, Handle, Id, Lang, LastOnlineAt,
                Location, Metadata, Timezone, UpdatedAt);
        }
    }
}