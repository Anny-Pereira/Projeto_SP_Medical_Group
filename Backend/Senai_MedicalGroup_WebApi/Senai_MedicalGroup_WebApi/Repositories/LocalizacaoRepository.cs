using MongoDB.Driver;
using Senai_MedicalGroup_WebApi.Domains;
using Senai_MedicalGroup_WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_MedicalGroup_WebApi.Repositories
{
    public class LocalizacaoRepository : ILocalizacaoRepository
    {

        //readonly indica que a variavel é somente de leitura
        private readonly IMongoCollection<Localizacao> _localizacao;

        public LocalizacaoRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");

            var database = client.GetDatabase("SpMedGroup");

            _localizacao = database.GetCollection<Localizacao>("mapas");
        }

        public void Cadastrar(Localizacao novaLocalizacao)
        {
            _localizacao.InsertOne(novaLocalizacao);
        }

        public List<Localizacao> ListarTodas()
        {
            return _localizacao.Find(localizacao => true).ToList();
        }
    }
}
