using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Security.Cryptography.Xml;
using System.Text.Json.Nodes;
using System.IO;
using ApiForm.Entity;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace ApiForm
{
    public partial class Form1 : Form
    {





        public Form1()
        {
            InitializeComponent();



        }

        Context.DbContext db = new Context.DbContext();

        private void Form1_Load(object sender, EventArgs e)
        {




        }

        public void Delete()

        {
            var id = textBox1.Text;

            string url = "https://www.balldontlie.io/api/v1/players/" + id;
            var client = new RestClient(url);

            var request = new RestRequest();

            var response = client.ExecuteGet(request);

            Entity.Player player = JsonConvert.DeserializeObject<Entity.Player>(response.Content!)!;

            db.Player.Find(player.id);

            var delete = db.Player.Find(player.id);
            db.Player.Remove(delete);
            db.SaveChanges();




        }

        private void button2_Click(object sender, EventArgs e)
        {


            Root root = new Root();
            Player player = new Player();
            Team team = new Team();

            RootTeam root2 = new RootTeam();


            string url = "https://www.balldontlie.io/api/v1/players/";



            var client = new RestClient(url);


            var request = new RestRequest();


            // request.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiI4YTQzMTYwZmM0YzBiNDliNzNkMTg0NjllMGExZTVjYiIsInN1YiI6IjY1MWEwZmU3MjIzYThiMDEwMzI5NWVkZiIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.pXXV642Cf85xU_pJ7oxwF_MEwvkggQayitvKQMUv1Ao");
            /// "authoriation , ardýndan token tipi  bearer - apikey/ key ...  key varsa bunu ekleyip ulasilabiliyor veriye.

            var response = client.ExecuteGet(request);

            Entity.Root players = JsonConvert.DeserializeObject<Entity.Root>(response.Content!)!;



            string urls = "https://www.balldontlie.io/api/v1/teams";

            var clients = new RestClient(urls);
            var requests = new RestRequest();
            var response2 = clients.ExecuteGet(requests);

            Entity.RootTeam TM = JsonConvert.DeserializeObject<Entity.RootTeam>(response2.Content!)!;

            /*   foreach (var item1 in TM.data)
               {
                   team.id = item1.id;
                   team.city = item1.city;
                   team.full_name = item1.full_name;
                   team.name = item1.name;
                   team.abbreviation = item1.abbreviation;
                   team.conference = item1.conference;

                   db.Team.Add(team);
                   db.SaveChanges();

               }*/



            foreach (var item in players.data)
            {

                var id = item.id;
                var g = db.Player.Find(id);

                if (g == null)
                {
                    player.id = item.id;
                    player.first_name = item.first_name;
                    player.last_name = item.last_name;
                    player.position = item.position;

                    player.height_feet = item.height_feet;
                    player.weight_pounds = item.weight_pounds;
                    player.teamid = item.team.id;

                    db.Player.Add(player);

                }
                else
                {
                    g.first_name = item.first_name;
                    
                    g.last_name = item.last_name;
                    g.position = item.position;

                   g.height_feet = item.height_feet;
                    g.weight_pounds = item.weight_pounds;
                    g.teamid = item.team.id;

                }
               
                db.SaveChanges();

            }


           




        }

        private void button1_Click(object sender, EventArgs e)
        {
            Delete();
        }
    }
}