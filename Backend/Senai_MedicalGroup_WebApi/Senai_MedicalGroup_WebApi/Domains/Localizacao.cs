using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_MedicalGroup_WebApi.Domains
{
    public class Localizacao
    {
        //id do tipo binary json
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }


        [BsonElement("latitude")]
        [BsonRequired]
        public string Latitude { get; set; }


       // [BsonElement("longitude")]
        [BsonRequired]
        public string Longitude { get; set; }


        [BsonRequired]
        public string Especialidade { get; set; }


        [BsonRequired]
        public string Endereco { get; set; }

    }
}
