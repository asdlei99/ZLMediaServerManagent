using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using STRealVideo.Lib.Models;
using ZLMediaServerManagent.DataBase;
using ZLMediaServerManagent.Models.Dto;
using ZLMediaServerManagent.Models.ViewDto;

namespace ZLMediaServerManagent.Commons
{
    /// <summary>
    /// 全局缓存
    /// </summary>
    public static class GloableCache
    {
        /// <summary>
        /// 访问全局客户端
        /// </summary>
        public static STRealVideo.Lib.ZLClient ZLClient = null;

        /// <summary>
        /// ZLServer是否在线
        /// </summary>
        /// <value></value>
        public static bool ZLServerOnline { get; set; }

        /// <summary>
        /// 在线用户
        /// </summary>
        /// <typeparam name="String">客户端Id (随机生成guid)</typeparam>
        /// <typeparam name="OnlineClientTokenInfo">(客户端详细)</typeparam>
        public static Dictionary<String, OnlineClientTokenInfo> OnlineClients = new Dictionary<String, OnlineClientTokenInfo>();

        /// <summary>
        /// 表示系统是否已经经过初始化配置，如果没有，访问任意页面将被重定向到初始化页面
        /// 主要通过配置表中媒体服务器IP来判断是否经过初始化
        /// </summary>
        public static bool IsInitServer => !string.IsNullOrWhiteSpace(DataBaseCache.Configs.Where(p => p.ConfigKey == ConfigKeys.ZLMediaServerIp).FirstOrDefault()?.ConfigValue);


        /// <summary>
        /// ZL服务器配置
        /// </summary>
        public static Dictionary<String, String> ZLMediaServerConfig = new Dictionary<string, string>();

        /// <summary>
        /// 拉流的截图缓存
        /// </summary>
        /// <typeparam name="long">流Id</typeparam>
        /// <typeparam name="byte[]">jpeg格式图片</typeparam>
        public static Dictionary<long, byte[]> StreamProxyImages = new Dictionary<long, byte[]>();



        public static System.Collections.Concurrent.ConcurrentBag<MediaStream> MediaStreams = new ConcurrentBag<STRealVideo.Lib.Models.MediaStream>();

    }
}
