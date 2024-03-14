using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace PigGame.Models
{
    public static class Session
    {
        public static void SetObject<T>(this ISession session, string key, T value)
            {
                session.SetString(key, JsonConvert.SerializeObject(value));
            }

            public static T GetObject<T>(this ISession session, string key)
            {
                var valueJson = session.GetString(key);
                if (string.IsNullOrEmpty(valueJson))
                    return default(T);
                else
                    return JsonConvert.DeserializeObject<T>(valueJson);


            }
    }

    public class GameSession
    {
        private const string GameKey = "pigGame";
        private ISession session;
        public GameSession(ISession sess) => session = sess;

        public Game GetGame() => session.GetObject<Game>(GameKey)
            ?? new Game();
        public void SetGame(Game game) => session.SetObject(GameKey, game);



    }
}

