﻿using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Sound : Singleton<Sound>
{
    // 资源目录
    public string ResourceDir = "";

    AudioSource m_bgSound;
    AudioSource m_effectSound;

    protected override void Awake()
    {
        base.Awake();
        m_bgSound = this.gameObject.AddComponent<AudioSource>();
        m_bgSound.playOnAwake = false;
        m_bgSound.loop = true;

        m_effectSound = this.gameObject.AddComponent<AudioSource>();

    }


    // 音乐音量大小
    public float BgVolume
    {
        get { return m_bgSound.volume; }
        set { m_bgSound.volume = value; }
    }

    // 音效音量大小
    public float EffectVolume
    {
        get { return m_effectSound.volume; }
        set { m_effectSound.volume = value; }
    }

    // 播放音乐
    public void PlayBg(string audioName)
    {
        string oldName;
        if(m_bgSound.clip == null)
        {
            oldName = "";
        }
        else
        {
            oldName = m_bgSound.clip.name;
        }
        if(oldName != audioName)
        {
            // 音乐文件路径
            string path;
            if(string.IsNullOrEmpty(ResourceDir))
            {
                path = "" + audioName;
            }
            else
            {
                path = ResourceDir + "/" + audioName;
            }
            // 加载音乐文件
            AudioClip clip = Resources.Load<AudioClip>(path);
            // 播放
            if (clip != null)
            {
                m_bgSound.clip = clip;
                m_bgSound.Play();
            }
        }
    }
    // 停止音乐
    public void StopBg()
    {
        m_bgSound.Stop();
        m_bgSound.clip = null;
    }

    // 播放音效
    public void PlayEffect(string audioName)
    {
        // 路径
        string path;
        if (string.IsNullOrEmpty(ResourceDir))
        {
            path = "" + audioName;
        }
        else
        {
            path = ResourceDir + "/" + audioName;
        }
        // 音频
        AudioClip clip = Resources.Load<AudioClip>(path);
        // 播放
        if (clip != null)
        {
            m_effectSound.PlayOneShot(clip);
        }
    }
}