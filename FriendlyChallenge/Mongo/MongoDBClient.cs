using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendlyChallenge.Mongo
{
    public static class MongoDBClient
    {
        private static MongoClient mongoClient { get; set; }

        public static MongoClient GetMongoClient()
        {
            if (mongoClient == null)
                mongoClient = new MongoClient();

            return mongoClient;
        }
    }
}
