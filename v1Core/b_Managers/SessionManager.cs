using Alexa.NET.Request;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace RateMeSoftly
{
    class SessionManager : Core
    {
        public static void Set(string key, object val)
        {
            APLSkillRequest request = Input.GetRequest();
            if (request.Session == null)
                request.Session = new Session();
            if (request.Session.Attributes == null)
                request.Session.Attributes = new Dictionary<string, object>();

            string jsonString = JsonConvert.SerializeObject(val);
            if (Contains(key))
                request.Session.Attributes[key] = jsonString;
            else
                request.Session.Attributes.Add(key, jsonString);

            Logger.Write($"Session attribute key: [{key}] & value: [{JsonConvert.SerializeObject(val)}] added");
        }

        public static T Get<T>(string key)
        {
            APLSkillRequest request = Input.GetRequest();

            if (Contains(key))
            {
                T output = JsonConvert.DeserializeObject<T>(request.Session.Attributes[key].ToString());
                return output;
            }

            throw new NullReferenceException($"Error: The given key [{key}] does not exist in the current session");
        }

        public static void Remove(params string[] keys)
        {
            foreach (string key in keys)
            {
                if (Contains(key))
                {
                    APLSkillRequest request = Input.GetRequest();
                    request.Session.Attributes.Remove(key);
                    Logger.Write($"Session attribute key: [{key}] removed");
                }
            }
        }

        public static bool Contains(string key)
        {
            Session session = Input.GetRequest().Session;
            if (session != null & session.Attributes != null)
                return session.Attributes.ContainsKey(key) ? true : false;

            return false;
        }

        public static void Clear()
        {
            APLSkillRequest request = Input.GetRequest();
            if (request.Session == null)
                request.Session = new Session();

            request.Session.Attributes = new Dictionary<string, object>();
            Logger.Write("Session attributes all cleared");
        }
    }
}
