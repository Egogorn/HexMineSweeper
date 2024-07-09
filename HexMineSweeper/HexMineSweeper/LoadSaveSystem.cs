using System.Diagnostics;
using Newtonsoft.Json;

namespace HexMineSweeper
{
    internal class LoadSaveSystem
    {
        public LoadSaveSystem() { }
        public void Save(GameObject gameState, string filename)
        {
            string json = JsonConvert.SerializeObject(gameState);
            File.WriteAllText(filename, json);
        }
        public GameObject Load(string path)
        {
            string json = File.ReadAllText(path);
            GameObject loadedGame = JsonConvert.DeserializeObject<GameObject>(json);
            return loadedGame;
        }
    }
}