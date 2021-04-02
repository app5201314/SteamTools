﻿#if (DEBUG && !UI_DEMO) || (!DEBUG && UI_DEMO)
using System.Application.Models;
using System.Application.Services.CloudService.Clients.Abstractions;
using System.Collections.Generic;
using System.IO.FileFormats;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using static System.Application.Services.ICloudServiceClient;

namespace System.Application.Services.CloudService
{
    public sealed class MockCloudServiceClient : ICloudServiceClient, IAccountClient, IManageClient, IAuthMessageClient, IVersionClient, IActiveUserClient, IAccelerateClient, ISteamCommunityClient
    {
        public string ApiBaseUrl => DefaultApiBaseUrl;
        public IAccountClient Account => this;
        public IManageClient Manage => this;
        public IAuthMessageClient AuthMessage => this;
        public IVersionClient Version => this;
        public IActiveUserClient ActiveUser => this;
        public IAccelerateClient Accelerate => this;
        public ISteamCommunityClient SteamCommunity => this;

        public Task<IApiResponse<string>> ChangeBindPhoneNumber(ChangePhoneNumberRequest.Validation request)
        {
            return Task.FromResult(ApiResponse.Ok("123"));
        }

        public Task<IApiResponse> ChangeBindPhoneNumber(ChangePhoneNumberRequest.New request)
        {
            return Task.FromResult(ApiResponse.Ok());
        }

        public Task<IApiResponse<AppVersionDTO?>> CheckUpdate(Guid id, Platform platform, DeviceIdiom deviceIdiom, ArchitectureFlags supportedAbis, Version osVersion, ArchitectureFlags abi)
        {
            return Task.FromResult(ApiResponse.Ok<AppVersionDTO?>(default));
        }

        public Task<IApiResponse<ClockInResponse>> ClockIn()
        {
            return Task.FromResult(ApiResponse.Ok(new ClockInResponse
            {
                Level = 99,
            }));
        }

        public Task<IApiResponse> DeleteAccount()
        {
            return Task.FromResult(ApiResponse.Ok());
        }

        public Task<IApiResponse> Download(bool isAnonymous, string requestUri, string cacheFilePath, IProgress<float> progress, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(ApiResponse.Ok());
        }

        public Task<HttpResponseMessage> Forward(HttpRequestMessage request, HttpCompletionOption completionOption, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IApiResponse<LoginOrRegisterResponse>> LoginOrRegister(LoginOrRegisterRequest request)
        {
            return Task.FromResult(ApiResponse.Ok(new LoginOrRegisterResponse
            {
                AuthToken = new JWTEntity
                {
                    AccessToken = "123",
                    ExpiresIn = DateTimeOffset.MaxValue,
                    RefreshToken = "321",
                },
                IsLoginOrRegister = true,
                User = new UserInfoDTO
                {
                    Level = 98,
                    NickName = "User",
                },
            }));
        }

        public Task<IApiResponse> Post(ActiveUserRecordDTO record)
        {
            return Task.FromResult(ApiResponse.Ok());
        }

        public Task<IApiResponse<JWTEntity>> RefreshToken(string refresh_token)
        {
            throw new NotImplementedException();
        }

        public ValueTask<IApiResponse> SendSms(SendSmsRequest request)
        {
            return new ValueTask<IApiResponse>(ApiResponse.Ok());
        }

        public Task<IApiResponse<List<ScriptDTO>>> Scripts()
        {
            var list = new List<ScriptDTO>
            {
                new ScriptDTO
                {
                    Name = "GM",
                    Version = "0.1",
                    Author = "软妹币玩家",
                    Description = "基础脚本框架(不建议取消勾选，会导致某些脚本无法运行)",
                },
            };
            return Task.FromResult(ApiResponse.Ok(list));
        }

        public Task<IApiResponse<List<AccelerateProjectGroupDTO>>> All()
        {
            var list = new List<AccelerateProjectGroupDTO>
            {
                new AccelerateProjectGroupDTO
                {
                    Name = "Steam 服务",
                    Items = new List<AccelerateProjectDTO>
                    {
                        new AccelerateProjectDTO
                        {
                            Name = "Steam社区",
                            DomainNames = "steamcommunity.com",
                            ForwardDomainName = "steamcommunity.rmbgame.net",
                            Hosts = "steamcommunity.com;www.steamcommunity.com",
                            Enable  = true,
                        },
                        new AccelerateProjectDTO
                        {
                            Name = "Steam商店",
                            DomainNames="store.steampowered.com;api.steampowered.com",
                            ForwardDomainName = "steamstore.rmbgame.net",
                            Hosts = "store.steampowered.com;api.steampowered.com",
                            Enable  = false,
                        },
                        new AccelerateProjectDTO
                        {
                            Name = "Steam更新",
                            DomainNames="media.steampowered.com",
                            ForwardDomainName="steammedia.rmbgame.net",
                            Hosts = "media.steampowered.com",
                            Enable = false,
                        },
                        new AccelerateProjectDTO
                        {
                            Name = "Steam图片",
                            DomainNames="steamcdn-a.akamaihd.net;steamuserimages-a.akamaihd.net;cdn.akamai.steamstatic.com",
                            ForwardDomainName="steamimage.rmbgame.net",
                            Hosts = "steamcdn-a.akamaihd.net;steamuserimages-a.akamaihd.net;cdn.akamai.steamstatic.com",
                            Enable = false,
                        },
                        new AccelerateProjectDTO
                        {
                            Name = "Steam图片上传",
                            DomainNames="steamcloud-ugc-hkg.oss-cn-hongkong.aliyuncs.com",
                            ForwardDomainName="steamcloud-ugc.rmbgame.net",
                            //ForwardDomainIP = "47.97.233.33",
                            Hosts = "steamcloud-ugc-hkg.oss-cn-hongkong.aliyuncs.com",
                            Enable = false,
                        },
                        new AccelerateProjectDTO
                        {
                            Name = "Steam好友聊天",
                            DomainNames="steam-chat.com",
                            ForwardDomainName="steamchat.rmbgame.net",
                            Hosts = "steam-chat.com",
                            Enable = false,
                        },
                    },
                },
                new AccelerateProjectGroupDTO
                {
                    Name = "Discord 语音聊天",
                    Items = new List<AccelerateProjectDTO>
                    {
                        new AccelerateProjectDTO
                        {
                            Name = "Discord 语音",
                            DomainNames = "discordapp.com",
                            ForwardDomainName = "discord.rmbgame.net",
                            Hosts = "discordapp.com;support.discordapp.com;url9177.discordapp.com;canary-api.discordapp.com;cdn-ptb.discordapp.com;ptb.discordapp.com;status.discordapp.com;cdn-canary.discordapp.com;cdn.discordapp.com;streamkit.discordapp.com;i18n.discordapp.com;url9624.discordapp.com;url7195.discordapp.com;merch.discordapp.com;printer.discordapp.com;canary.discordapp.com;apps.discordapp.com;pax.discordapp.com;1.0.0.1 dl.discordapp.net;1.0.0.1 media.discordapp.net;1.0.0.1 images-ext-2.discordapp.net;1.0.0.1 images-ext-1.discordapp.net",
                            Enable  = false,
                        },
                        new AccelerateProjectDTO
                        {
                            Name = "Discord 更新和图片下载",
                            DomainNames = "ddiscordapp.net",
                            ForwardDomainName = "discordnet.rmbgame.net",
                            //ForwardDomainIP = "162.159.128.232",
                            Hosts = "dl.discordapp.net;media.discordapp.net;images-ext-2.discordapp.net;images-ext-1.discordapp.net",
                            Enable  = false,
                        },
                    },
                },
                new AccelerateProjectGroupDTO
                {
                    Name = "Twitch 直播",
                    Items = new List<AccelerateProjectDTO>
                    {
                        new AccelerateProjectDTO
                        {
                            Name = "Twitch 直播网页加载",
                            DomainNames = "twitch.tv",
                            ForwardDomainName = "twitch.rmbgame.net",
                            Hosts = "twitch.tv;www.twitch.tv;m.twitch.tv;app.twitch.tv;music.twitch.tv;badges.twitch.tv;blog.twitch.tv;inspector.twitch.tv;stream.twitch.tv;dev.twitch.tv;clips.twitch.tv;spade.twitch.tv;gql.twitch.tv;vod-secure.twitch.tv;vod-storyboards.twitch.tv;trowel.twitch.tv;countess.twitch.tv;extension-files.twitch.tv;vod-metro.twitch.tv;pubster.twitch.tv;help.twitch.tv;passport.twitch.tv;id.twitch.tv;link.twitch.tv;id-cdn.twitch.tv;player.twitch.tv;api.twitch.tv;cvp.twitch.tv;clips-media-assets2.twitch.tv;client-event-reporter.twitch.tv;gds-vhs-drops-campaign-images.twitch.tv;us-west-2.uploads-regional.twitch.tv;assets.help.twitch.tv;discuss.dev.twitch.tv;pubsub-edge.twitch.tv;irc-ws.chat.twitch.tv;irc-ws-r.chat.twitch.tv",
                            //"platform.twitter.com",
                            Enable  = false,
                        },
                        new AccelerateProjectDTO
                        {
                            Name = "Twitch 直播聊天服务",
                            DomainNames = "irc-ws.chat.twitch.tv",
                            ForwardDomainName = "twitchchat.rmbgame.net",
                            //ForwardDomainIP = "52.38.70.182",
                            Hosts = "irc-ws.chat.twitch.tv;irc-ws-r.chat.twitch.tv",
                            Enable  = false,
                        },
                    },
                },
                new AccelerateProjectGroupDTO
                {
                    Name = "Origin",
                    Items = new List<AccelerateProjectDTO>
                    {
                        new AccelerateProjectDTO
                        {
                            Name = "Origin 游戏下载",
                            DomainNames = "origin-a.akamaihd.net",
                            ForwardDomainName = "originakamaidownload.rmbgame.net",
                            Hosts = "origin-a.akamaihd.net",
                            Enable  = false,
                        },
                    },
                },
                new AccelerateProjectGroupDTO
                {
                    Name = "Uplay",
                    Items = new List<AccelerateProjectDTO>
                    {
                        new AccelerateProjectDTO
                        {
                            Name = "Uplay 更新",
                            DomainNames = "static3.cdn.ubi.com",
                            ForwardDomainName = "ubisoftstatic3.rmbgame.net",
                            Hosts = "static3.cdn.ubi.com",
                            Enable  = false,
                        },
                    },
                },
                new AccelerateProjectGroupDTO
                {
                    Name = "GOG",
                    Items = new List<AccelerateProjectDTO>
                    {
                        new AccelerateProjectDTO
                        {
                            Name = "GOG 游戏平台",
                            DomainNames = "gog.com",
                            ForwardDomainName = "gog.rmbgame.net",
                            Hosts = "gog.com;www.gog.com;images.gog.com;images-1.gog.com;images-2.gog.com;images-3.gog.com;images-4.gog.com;webinstallers.gog.com;menu.gog.com;auth.gog.com;login.gog.com;api.gog.com;reviews.gog.com;insights-collector.gog.com;remote-config.gog.com;external-accounts.gog.com;chat.gog.com;presence.gog.com;external-users.gog.com;gamesdb.gog.com;gameplay.gog.com;cfg.gog.com;notifications.gog.com;users.gog.com",
                            Enable  = false,
                        },
                    },
                },
                new AccelerateProjectGroupDTO
                {
                    Name = "Google 验证码",
                    Items = new List<AccelerateProjectDTO>
                    {
                        new AccelerateProjectDTO
                        {
                            Name = "Google(Recaptcha)验证码",
                            DomainNames = "www.google.com",
                            ForwardDomainName = "www.recaptcha.net",
                            Hosts = "www.google.com",
                            Enable  = false,
                            Redirect=true,
                        },
                    },
                },
                new AccelerateProjectGroupDTO
                {
                    Name = "Github",
                    Items = new List<AccelerateProjectDTO>
                    {
                        new AccelerateProjectDTO
                        {
                            Name = "Github 图片Raw加载",
                            DomainNames = "githubusercontent.com;raw.github.com",
                            ForwardDomainName = "githubusercontent.rmbgame.net",
                            Hosts = "raw.github.com;githubusercontent.com;raw.githubusercontent.com;camo.githubusercontent.com;cloud.githubusercontent.com;avatars.githubusercontent.com;avatars0.githubusercontent.com;avatars1.githubusercontent.com;avatars2.githubusercontent.com;avatars3.githubusercontent.com;user-images.githubusercontent.com",
                            Enable  = false,
                        },
                        new AccelerateProjectDTO
                        {
                            Name = "Github Gist",
                            DomainNames = "gist.github.com",
                            ForwardDomainName = "github.com",
                            Hosts = "gist.github.com",
                            Enable  = false,
                        },
                    },
                },
                new AccelerateProjectGroupDTO
                {
                    Name = "Pixiv",
                    Items = new List<AccelerateProjectDTO>
                    {
                        new AccelerateProjectDTO
                        {
                            Name = "Pixiv 网站",
                            DomainNames = "pixiv.net",
                            ForwardDomainName = "pixiv.rmbgame.net",
                            Hosts = "www.pixiv.net;touch.pixiv.net;source.pixiv.net;accounts.pixiv.net;imgaz.pixiv.net;app-api.pixiv.net;oauth.secure.pixiv.net;dic.pixiv.net;comic.pixiv.net;factory.pixiv.net;g-client-proxy.pixiv.net;sketch.pixiv.net;payment.pixiv.net;sensei.pixiv.net;novel.pixiv.net;ssl.pixiv.net;times.pixiv.net;recruit.pixiv.net;pixiv.net;p2.pixiv.net;matsuri.pixiv.net;m.pixiv.net;iracon.pixiv.net;inside.pixiv.net;i1.pixiv.net;help.pixiv.net;goods.pixiv.net;genepixiv.pr.pixiv.net;festa.pixiv.net;en.dic.pixiv.net;dev.pixiv.net;chat.pixiv.net;blog.pixiv.net;embed.pixiv.net;comic-api.pixiv.net;pay.pixiv.net",
                            Enable  = false,
                        },
                        new AccelerateProjectDTO
                        {
                            Name = "Pixiv 图片加载",
                            DomainNames = "pximg.net",
                            ForwardDomainName = "pximg.rmbgame.net",
                            Hosts = "pximg.net;i.pximg.net;s.pximg.net;img-sketch.pximg.net;source.pximg.net;booth.pximg.net;i-f.pximg.net;imp.pximg.net;public-img-comic.pximg.net",
                            Enable  = false,
                        },
                    },
                },
            };
            return Task.FromResult(ApiResponse.Ok(list));
        }

        public Task<IApiResponse<SteamMiniProfile>> MiniProfile(int steamId32)
        {
            var content = new SteamMiniProfile
            {
                Nameplate = new List<SteamMiniProfile.Nameplate_>
                {
                    new SteamMiniProfile.Nameplate_
                    {
                        Format = VideoFormat.WebM,
                        Src = "https://media.st.dl.pinyuncloud.com/steamcommunity/public/images/items/1504020/19511e3bc7b3d248b82cabdde810e7aea3d2b6f1.webm",
                    },
                    new SteamMiniProfile.Nameplate_
                    {
                        Format = VideoFormat.MP4,
                        Src = "https://media.st.dl.pinyuncloud.com/steamcommunity/public/images/items/1504020/74ded39af957315c5bba17202489bbed570135ec.mp4",
                    },
                },
                PlayerSection = new SteamMiniProfile.PlayerSection_
                {
                    AvatarFrame = "https://media.st.dl.pinyuncloud.com/steamcommunity/public/images/items/212070/9b6b26c7a03046da283408d72319f9eec932c80a.gif",
                    Avatar = "https://media.st.dl.pinyuncloud.com/steamcommunity/public/images/items/1504020/bc6fc1f46697d79a8add0e30862d74dbaf50cc4d.gif",
                    Persona = "RuaRua",
                    FriendStatus = "在线",
                },
                Detailssection = new SteamMiniProfile.Detailssection_
                {
                    Badge = "https://community.akamai.steamstatic.com/public/images/badges/26_summer2017_sticker/completionist.png",
                    BadgeName = "贴纸完满主义者",
                    BadgeXp = "100 点经验值",
                    PlayerLevel = ushort.MaxValue,
                },
            };
            var rsp = ApiResponse.Ok(content);
            return Task.FromResult(rsp);
        }
    }
}
#endif