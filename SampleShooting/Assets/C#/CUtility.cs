using UnityEngine;

// 便利な関数を管理する静的クラス
public static class CUtility
{
    // 移動可能な範囲
    static Vector2 MoveLimitTopLeft = new Vector2(-5.7f, 4.2f);
    static Vector2 MoveLimitButtomRight = new Vector2(1.7f, -4.2f);

    static Vector2 EnemyLimitTopLeft = new Vector2(-7.0f, 6.2f);
    static Vector2 EnemyLimitButtomRight = new Vector2(3.0f, -5.2f);
    // 指定された位置を移動可能な範囲に収めた値を返す
    public static Vector3 ClampPosition(Vector3 position)
    {
        return new Vector3
        (
            Mathf.Clamp(position.x, MoveLimitTopLeft.x, MoveLimitButtomRight.x),
            Mathf.Clamp(position.y, MoveLimitButtomRight.y, MoveLimitTopLeft.y),
            0
        );
    }
    public static bool IsOut(Vector3 position)
    {
        return (position.x < EnemyLimitTopLeft.x ||
               EnemyLimitTopLeft.y < position.y ||
                EnemyLimitButtomRight.x < position.x ||
                position.y < EnemyLimitButtomRight.y);
    }
    // 引数に角度（ 0 ～ 360 ）を渡すとベクトルに変換して返す
    public static Vector3 GetDirection360(float angle360)
    {
        float angle = angle360 * Mathf.Deg2Rad;
        return new Vector3
        (
            Mathf.Cos(angle),
            Mathf.Sin(angle),
            0
        );
    }
    // 引数に角度（ 0 ～ 1.0f ）を渡すとベクトルに変換して返す
    public static Vector3 GetDirection1(float angle1)
    {
        float angle = angle1 / (3.14f * 2);
        return new Vector3
        (
            Mathf.Cos(angle),
            Mathf.Sin(angle),
            0
        );
    }
    // 引数に角度（ 0 ～ PI2 ）を渡すベクトルに変換して返す
    public static Vector3 GetDirectionPI2(float angle_pi2)
    {
        return new Vector3
        (
            Mathf.Cos(angle_pi2),
            Mathf.Sin(angle_pi2),
            0
        );
    }
    ///【機能】マルチプルスプライトからスライスしたスプライトを取得する
    ///【第1引数】スプライトファイル名（正確にはResources フォルダからのスプライトファイルまでのパス）
    ///【第2引数】取得したいスライスされたスプライト名
    ///【戻り値】取得したスプライト
    public static Sprite GetSprite(string fileName, string spriteName)
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>(fileName);
        return System.Array.Find<Sprite>(sprites, (sprite) => sprite.name.Equals(spriteName));
    }
}
