using Amazon.DynamoDBv2.DataModel;
using System.Collections.Generic;

namespace RateMeSoftly
{
    [DynamoDBTable(SessionKey.DbTableName)]
    public class State
    {
        [DynamoDBHashKey]
        public string UserId { get; set; }
        public int Ok { get; set; }
        public int Bad { get; set; }
        public int Good { get; set; }
        public int VeryBad { get; set; }
        public int VeryGood { get; set; }
        public int NumPlayed { get; set; }
        public int NumPrompted { get; set; }
        public List<Utterance> Utterances { get; set; }
    }
}
