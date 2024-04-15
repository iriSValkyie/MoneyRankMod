using StardewModdingAPI;
using StardewValley;
using StardewValley.Menus;


namespace StardewValleyMoneyRankMod
{
    public class MoneyRank
    {
        private List<MoneyRankData> m_Ranks = new List<MoneyRankData>();

        private int showRankIn =5;
        public bool IsInit
        {
            get => m_Ranks.Count == 0 ? false : true;
        }
        public MoneyRank()
        {
            
        }

        public void Init()                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
        {
            int count = Game1.getAllFarmers().Count();
            for (int i = 0; i < count; i++)
            {
                m_Ranks.Add(new MoneyRankData("",0));
            }
        }

        public void ShowRankingUI(IMonitor debug)
        {
            IOrderedEnumerable<MoneyRankData> ranking = GetRanking();
            string message = "-稼いだ金額ランキング-\n";
            /*
            debug.Log("-稼いだ金額ランキング-",LogLevel.Debug);
            foreach (var rank in ranking.Select((value,index)=>(value,index)))
            {
                debug.Log($"{rank.index + 1}位 | {rank.value.Name} | {rank.value.TotalMoney:N0} G |" ,LogLevel.Debug);
            }*/

            for (int i = 0; i < showRankIn; i++)
            {
                if (i >= ranking.Count()) continue;
                MoneyRankData data = ranking.ElementAt(i);

                message += $"{i + 1}位{data.Name}\n";
                message += $"{data.TotalMoney:N0}G\n";
            }
            /*
            foreach (var rank in ranking.Select((value,index)=>(value,index)))
            {
                message += $"{rank.index + 1}位 | {rank.value.Name} | {rank.value.TotalMoney:N0} G |\n";
            }
            */
            string parseMessage = Game1.parseText(message, Game1.smallFont, Game1.viewport.Width);
            HUDMessage hud = new HUDMessage(parseMessage)
            {
                noIcon = true,
                timeLeft = 5250f
            };
            Game1.addHUDMessage(hud);
        }

        private IOrderedEnumerable<MoneyRankData> GetRanking()
        {
            IEnumerable<Farmer> farmers = Game1.getAllFarmers();

            foreach (var farmer in farmers.Select((value,index)=>(value,index)))
            {
                if (farmer.index > m_Ranks.Count)
                {
                    m_Ranks.Add(new MoneyRankData("",0));
                };
                string name = farmer.value.Name;
                uint totalMoney = farmer.value.stats.IndividualMoneyEarned;
                m_Ranks[farmer.index].Name = name;
                m_Ranks[farmer.index].TotalMoney = totalMoney;
            }

            return m_Ranks.OrderByDescending(f => f.TotalMoney);
            
        }
    }
    
}