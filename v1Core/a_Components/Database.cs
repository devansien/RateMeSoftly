using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Runtime;
using System;
using System.Threading.Tasks;

namespace RateMeSoftly
{
    public class Database : Core
    {
        protected string UserId { get; private set; }
        protected State Save { get; private set; }
        protected DynamoDBContext DbContext { get; private set; }
        protected AmazonDynamoDBClient Client { get; private set; }


        public Database(string userId)
        {
            UserId = userId;

            string accessKey = Environment.GetEnvironmentVariable(SessionKey.DbAccessKey);
            string secretKey = Environment.GetEnvironmentVariable(SessionKey.DbSecretKey);
            BasicAWSCredentials credentials = new BasicAWSCredentials(accessKey, secretKey);

            Client = new AmazonDynamoDBClient(credentials, RegionEndpoint.USEast1);
        }

        public void SetContext()
        {
            DynamoDBContextConfig config = new DynamoDBContextConfig()
            {
                TableNamePrefix = SkillMetadata.DbTablePrefix
            };

            DbContext = new DynamoDBContext(Client, config);
        }

        public async Task<State> GetState()
        {
            Save = await DbContext.LoadAsync<State>(UserId);
            Save = StateManager.ValidateState(UserId, Save);

            return Save;
        }

        public async Task SaveState()
        {
            await DbContext.SaveAsync(Save);
        }
    }
}
