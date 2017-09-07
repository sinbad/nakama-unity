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

namespace Nakama
{
    internal class NNotification : INNotification
    {
        public byte[] Id { get; private set; }
        public string Subject { get; private set; }
        public byte[] Content { get; private set; }
        public long Code { get; private set; }
        public byte[] SenderId { get; private set; }
        public long CreatedAt { get; private set; }
        public long ExpiresAt { get; private set; }
        public bool Persistent { get; private set; }

        internal NNotification(Notification n)
        {
            Id = n.Id.ToByteArray();
            Subject = n.Subject;
            Content = n.Content.ToByteArray();
            Code = n.Code;
            SenderId = n.SenderId.ToByteArray();
            CreatedAt = n.CreatedAt;
            ExpiresAt = n.ExpiresAt;
            Persistent = n.Persistent;
        }

        public int CompareTo(INNotification other)
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

        public static bool operator >(NNotification self, NNotification other)
        {
            return self.CompareTo(other) == 1;
        }

        public static bool operator <(NNotification self, NNotification other)
        {
            return self.CompareTo(other) == -1;
        }

        public static bool operator >=(NNotification self, NNotification other)
        {
            return self.CompareTo(other) >= 0;
        }

        public static bool operator <=(NNotification self, NNotification other)
        {
            return self.CompareTo(other) <= 0;
        }

        public bool Equals(INNotification other)
        {
            return CompareTo(other) == 0;
        }

        public override string ToString()
        {
            const string f =
                "NNotification(Id={0},Subject={1},Content={2},Code={3},SenderId={4},CreatedAt={5},ExpiresAt={6},Persistent={7})";
            return string.Format(f, Id, Subject, Content, Code, SenderId, CreatedAt, ExpiresAt, Persistent);
        }
    }
}