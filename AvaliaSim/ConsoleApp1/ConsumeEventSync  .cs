using DomainModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ConsumeEventSync
    {

        // GetAll
        public void GetAllEventData() //Get All Events Records  
        {
            using (var client = new WebClient()) //WebClient  
            {
                client.Headers.Add("Content-Type:application/json"); //Content-Type  
                client.Headers.Add("Accept:application/json");
                var result = client.DownloadString("http://localhost:51346/api/Avaliacao"); //URI  
     //           Console.WriteLine(Environment.NewLine + result);

                List<Avaliacao> model = null;
                model = JsonConvert.DeserializeObject<List<Avaliacao>>(result);

                Console.WriteLine("Listando Todos os " + model.Count + " registros:");
                Console.Write("-------------------------- \n");
                foreach (var item in model)
                {
                    Console.Write("Id: " + item.Id + "\n");
                    Console.Write("Nome: " + item.nome + "\n");
                    Console.Write("Cidade: " + item.cidade + "\n");
                    Console.Write("Estado: " + item.estado + "\n");
                    Console.Write("Data da criação: " + item._data + "\n");
                    Console.Write("-------------------------- \n");
                }
            }

        }

        // Busca
        public void GetAllEventData_ByEventID(string nome) //Get All Events Records By ID  
        {
            using (var client = new WebClient()) //WebClient  
            {
                client.Headers.Add("Content-Type:application/json"); //Content-Type  
                client.Headers.Add("Accept:application/json");
                var result = client.DownloadString("http://localhost:51346/api/Avaliacao/" + nome); //URI  
     //           Console.WriteLine(Environment.NewLine + result);

                List<Avaliacao> model = null;
                model = JsonConvert.DeserializeObject<List<Avaliacao>>(result);

                Console.WriteLine("Listando Todos os " + model.Count + " registros:");
                Console.Write("-------------------------- \n");
                foreach (var item in model)
                {
                    Console.Write("Id: " + item.Id + "\n");
                    Console.Write("Nome: " + item.nome + "\n");
                    Console.Write("Cidade: " + item.cidade + "\n");
                    Console.Write("Estado: " + item.estado + "\n");
                    Console.Write("Data da criação: " + item._data + "\n");
                    Console.Write("-------------------------- \n");
                }
            }
        }

        // Add
        public void PostEvent_data(Avaliacao av) //Adding Event  
        {
            using (var client = new WebClient())
            {
                Avaliacao avaliacao = new Avaliacao(); //Setting parameter to post  
                avaliacao.nome = av.nome;
                avaliacao.cidade = av.cidade;
                avaliacao.estado = av.estado;
                avaliacao.tipo = av.tipo;
                client.Headers.Add("Content-Type:application/json");
                client.Headers.Add("Accept:application/json");
                var result = client.UploadString("http://localhost:51346/api/Avaliacao", JsonConvert.SerializeObject(avaliacao));
                Console.WriteLine(result);
                Console.WriteLine("Avaliação adicionada com sucesso!");
            }
        }

        //Edit
        public void PutEvent_data(int EventID, Avaliacao av) //Update Event  
        {
            using (var client = new WebClient())
            {
                Avaliacao avaliacao = new Avaliacao(); //Setting parameter to post  
                avaliacao.nome = av.nome;
                avaliacao.cidade = av.estado;
                avaliacao.estado = av.cidade;
                avaliacao.tipo = av.tipo;
                client.Headers.Add("Content-Type:application/json");
                client.Headers.Add("Accept:application/json");
                var result = client.UploadString("http://localhost:51346/api/Avaliacao/" + EventID, "PUT", JsonConvert.SerializeObject(avaliacao));
                Console.WriteLine(result);
            }
        }

        //Delete
        public void DeleteEvent_data(int EventID) //Update Event  
        {
            using (var client = new WebClient())
            {
                client.Headers.Add("Content-Type:application/json");
                client.Headers.Add("Accept:application/json");
                var result = client.UploadString("http://localhost:51346/api/Avaliacao/" + EventID, "Delete", "");
                Console.WriteLine(result);
            }
        }
    }
}
