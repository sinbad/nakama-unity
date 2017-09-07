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
    internal class NUserPresence : INUserPresence
    {
        public byte[] UserId { get; private set; }
        public byte[] SessionId { get; private set; }
        public string Handle { get; private set; }

        internal NUserPresence(UserPresence message)
        {
            UserId = message.UserId.ToByteArray();
            SessionId = message.SessionId.ToByteArray();
            Handle = message.Handle;
        }

        public int CompareTo(INUserPresence other)
        {
            return string.Compare(Handle, other.Handle, StringComparison.Ordinal);
        }

        public static bool operator >(NUserPresence self, NUserPresence other)
        {
            return self.CompareTo(other) == 1;
        }

        public static bool operator <(NUserPresence self, NUserPresence other)
        {
            return self.CompareTo(other) == -1;
        }

        public static bool operator >=(NUserPresence self, NUserPresence other)
        {
            return self.CompareTo(other) >= 0;
        }

        public static bool operator <=(NUserPresence self, NUserPresence other)
        {
            return self.CompareTo(other) <= 0;
        }

        public bool Equals(INUserPresence other)
        {
            return CompareTo(other) == 0;
        }

        public override string ToString()
        {
            const string f = "NUserPresence(UserId={0},SessionId={1},Handle={2})";
            return string.Format(f, UserId, SessionId, Handle);
        }
    }
}