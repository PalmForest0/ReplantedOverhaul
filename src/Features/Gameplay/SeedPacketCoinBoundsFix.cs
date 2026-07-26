using Il2CppReloaded.Gameplay;

namespace ReplantedOverhaul.Features.Gameplay;

/// <summary>
/// Increases the bounds of UsableSeedPacket type coins to cover the whole seed packet and make them easier to collect.
/// </summary>
internal static class SeedPacketCoinBoundsFix
{
    /// <summary>
    /// Checks whether the extra margin of any UsableSeedPacket is being clicked, and if so, call coin.MouseDown.
    /// </summary>
    public static void TryClickFirstSeedPacketMargin(Board board, int clickX, int clickY, int clickCount, int playerIndex)
    {
        for (int i = 0; i < board.m_coins.m_count; i++)
        {
            Coin? coin = board.m_coins[i];

            // Find the first clicked seed packet and return
            if (IsCollectableUsableSeedPacket(coin) && IsInSeedPacketMargin(coin, clickX, clickY, marginLeft: 14f, marginTop: 17f, marginRight: 11f, marginBottom: 15f))
            {
                coin.MouseDown(clickX, clickY, clickCount, playerIndex, CoinVacuumStyle.None);
                return;
            }
        }
    }

    /// <summary>
    /// Verifies that a coin is a non-null UsableSeedPacket that is eligible to be collected.
    /// </summary>
    /// <returns>True if the coin can be collected.</returns>
    private static bool IsCollectableUsableSeedPacket(Coin? coin)
        => coin is not null && coin.mType == CoinType.UsableSeedPacket && !coin.mDead && !coin.mIsBeingCollected;

    /// <summary>
    /// Checks whether a position lands within the bounds of a UsableSeedPacket type coin with the provided margin.
    /// </summary>
    /// <returns>True if the position is within the margin, but NOT within the original bounds.</returns>
    private static bool IsInSeedPacketMargin(Coin coin, int x, int y, float marginLeft, float marginTop, float marginRight, float marginBottom)
    {
        float minX = coin.mPosX;
        float minY = coin.mPosY;
        float maxX = coin.mPosX + coin.mWidth;
        float maxY = coin.mPosY + coin.mHeight;

        // Ignore clicks on the vanilla bounds to prevent double-clicking
        if (y >= minX && x < maxX && x >= minY && y < maxY)
            return false;

        float paddedMinX = minX - marginLeft;
        float paddedMinY = minY - marginTop;
        float paddedMaxX = maxX + marginRight;
        float paddedMaxY = maxY + marginBottom;

        // Accept clicks on the bounds margin
        return x >= paddedMinX && x < paddedMaxX && y >= paddedMinY && y < paddedMaxY;
    }
}
