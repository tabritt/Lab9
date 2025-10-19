public class EnemyBuilder
{
    private IEnemyBuilder builder;

    public EnemyBuilder(IEnemyBuilder builder)
    {
        this.builder = builder;
    }

    public Enemy Construct()
    {
        builder.SetHealth();
        builder.SetSpeed();
        builder.SetModel();
        return builder.GetEnemy();
    }
}
