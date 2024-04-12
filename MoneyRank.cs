using StardewModdingAPI;

namespace StardewValleyMoneyRankMod;

public class MoneyRank
{
    private List<long> m_ConnectingPlayerIDs = new List<long>();
    public MoneyRank()
    {
        
    }

    public void AddPlayer(IMultiplayerPeer peer)
    {
        m_ConnectingPlayerIDs.Add(peer.PlayerID);
    }

    public void RemovePlayer(IMultiplayerPeer peer)
    {
        m_ConnectingPlayerIDs.Remove(peer.PlayerID);
    }
}