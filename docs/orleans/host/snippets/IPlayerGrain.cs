public interface IPlayerGrain : IGrainWithGuidKey
{
    Task<GameState> JoinGame(Guid gameId);
}

[Serializable]
public enum GameState
{
    AwaitingPlayers,
    InPlay,
    Finished
};