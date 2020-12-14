using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CResourcesLoader<T> where T : UnityEngine.Object
{
    Dictionary<string, T> ResourcesHandles = new Dictionary<string, T>();

    public bool LoadObject(string file_name)
    {
        string fn = Path.GetFileName(file_name);

        if (ResourcesHandles.ContainsKey(fn))
        {
            Debug.Log("LoadObject()で同じ名前のキーがありました");
            Debug.Log(file_name + "にある" + fn + "の名前を変更してください");
            return false;
        }
        else
        {
            T ob = Resources.Load<T>(file_name);
            if (ob)
            {
                ResourcesHandles.Add(fn, ob);
                return true;
            }
            else
            {
                Debug.Log("LoadObject()" + file_name + "の読み込みが失敗しました");
                return false;
            }
        }
    }

    public bool LoadAllObjects(string file_name)
    {
        T[] obs = Resources.LoadAll<T>(file_name);

        if (obs.Length <= 0)
        {
            return false;
        }

        foreach (T ob in obs)
        {
            if (ResourcesHandles.ContainsKey(ob.name))
            {
                Debug.Log("LoadAllObject()で同じ名前のキーがありました");
                Debug.Log(file_name + "にある" + ob.name + "の名前を変更してください");
            }
            else
            {
                ResourcesHandles.Add(ob.name, ob);
            }
        }
        return true;
    }

    public T GetObjectHandle(string name)
    {
        if (ResourcesHandles.ContainsKey(name))
        {
            return ResourcesHandles[name];
        }
        else
        {

            return null;
        }
    }

    public bool ContainsKey(string key_name)
    {
        return ResourcesHandles.ContainsKey(key_name);
    }
}
public class CSoundPlayer
{
    static GameObject SoundPlayerObj, BGMPlayerObj;
    static CResourcesLoader<AudioClip> ResourcesLoader = new CResourcesLoader<AudioClip>();
    static AudioSource SoundAudioSource, BGMAudioSource;
    static CFadeTimer FadeTimer;

    public static IEnumerator SetFadeTimer(float start_val, float end_val, float end_time)
    {
        FadeTimer = new CFadeTimer(start_val, end_val, end_time);

        while (true)
        {
            float t = FadeTimer.CalcTime();
            BGMAudioSource.volume = t;

            if (t <= 0.0f)
            {
                BGMAudioSource.Stop();
                yield break;
            }
            else
            {
                yield return new WaitForSeconds(Time.deltaTime);
            }
        }
    }

    public static bool LoadAudioClip(string audio_path)
    {
        return ResourcesLoader.LoadObject(audio_path);
    }

    public static bool LoadAllSounds(string audio_path)
    {
        return ResourcesLoader.LoadAllObjects(audio_path);
    }

    public static bool StopSound(string se_name)
    {
        GameObject sound_obj = GameObject.Find(se_name);
        if (sound_obj)
        {
            AudioSource aus = sound_obj.GetComponent<AudioSource>();
            if (aus)
            {
                aus.Stop();
                return true;
            }
        }
        return false;
    }

    public static AudioClip GetAudioClip(string se_name)
    {
        if (ResourcesLoader.ContainsKey(se_name) == false)
        {
            return null;
        }
        else
        {
            return ResourcesLoader.GetObjectHandle(se_name);
        }
    }

    public static bool PlaySound(string se_name, bool se_flag = true)
    {
        if (ResourcesLoader.ContainsKey(se_name) == false)
        {
            return false;
        }

        if (se_flag)
        {
            if (SoundPlayerObj == null)
            {
                SoundPlayerObj = new GameObject("SoundPlayer");
                SoundAudioSource = SoundPlayerObj.AddComponent<AudioSource>();
            }
            SoundAudioSource.PlayOneShot(ResourcesLoader.GetObjectHandle(se_name));
        }
        else
        {
            if (BGMPlayerObj == null)
            {
                BGMPlayerObj = new GameObject("BGMPlayer");
                BGMAudioSource = BGMPlayerObj.AddComponent<AudioSource>();
                BGMAudioSource.clip = ResourcesLoader.GetObjectHandle(se_name);
                BGMAudioSource.volume = 1.0f;
                BGMAudioSource.loop = true;
                BGMAudioSource.Play();
            }
            else
            {
                if (BGMAudioSource)
                {
                    if (BGMAudioSource.isPlaying)
                    {
                        BGMAudioSource.Stop();
                    }
                    else
                    {
                        BGMAudioSource.Play();
                    }
                }
                else
                {
                    BGMAudioSource = BGMPlayerObj.AddComponent<AudioSource>();
                    if (BGMAudioSource)
                    {
                        BGMAudioSource.clip = ResourcesLoader.GetObjectHandle(se_name);
                        BGMAudioSource.volume = 1.0f;
                        BGMAudioSource.loop = true;
                        BGMAudioSource.Play();
                    }
                }
            }
        }

        return true;
    }
}

// 指定した時間である値からある値まで数を変化させる
// start_val 変化させたい数の初期値
// end_val	 変化させたい数の終了値
// end_time  終了時間(end_timeかけて終了させる)
// 使用手順
// 1 宣言する
// CFadeTimer FadeTimer;
// 2 初期化する
// FadeTimer = new CFadeTimer( 100, 1000, 3 );
// 3 毎ループ行う処理を追加する
// print( FadeTimer.CalcTime () );
public class CFadeTimer
{
    private bool Flag = true;
    private float StartVal, EndVal, StartTime, EndTime, Delta, Result = 0.0f;

    public CFadeTimer(float start_val, float end_val, float end_time)
    {
        StartVal = start_val;
        EndVal = end_val;
        EndTime = end_time;
        StartTime = Time.realtimeSinceStartup;
        Delta = (EndVal - StartVal) / EndTime;
    }

    public float CalcTime()
    {
        if (Flag)
        {
            float t = Time.realtimeSinceStartup - StartTime;
            if (EndTime <= t)
            {
                Flag = false;
                Result = EndVal;
                return Result;
            }
            Result = Delta * t + StartVal;
            return Result;
        }
        else
        {
            return -1.0f;
        }
    }
}
