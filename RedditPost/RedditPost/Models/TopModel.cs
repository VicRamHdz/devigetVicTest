﻿using System;
using System.Collections.Generic;
using RedditPost.Base;

namespace RedditPost.Models
{
    public class TopModel : ModelBase
    {
        public string kind { get; set; }
        public Data data { get; set; }
    }

    public class MediaEmbed
    {
        public string content { get; set; }
        public int? width { get; set; }
        public bool? scrolling { get; set; }
        public int? height { get; set; }
    }

    public class Oembed
    {
        public string provider_url { get; set; }
        public string description { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string type { get; set; }
        public string author_name { get; set; }
        public int height { get; set; }
        public int width { get; set; }
        public string html { get; set; }
        public int thumbnail_width { get; set; }
        public string version { get; set; }
        public string provider_name { get; set; }
        public string thumbnail_url { get; set; }
        public int thumbnail_height { get; set; }
        public string author_url { get; set; }
    }

    public class SecureMedia
    {
        public Oembed oembed { get; set; }
        public string type { get; set; }
    }

    public class SecureMediaEmbed
    {
        public string content { get; set; }
        public int? width { get; set; }
        public bool? scrolling { get; set; }
        public int? height { get; set; }
    }

    public class Oembed2
    {
        public string provider_url { get; set; }
        public string description { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string type { get; set; }
        public string author_name { get; set; }
        public int height { get; set; }
        public int width { get; set; }
        public string html { get; set; }
        public int thumbnail_width { get; set; }
        public string version { get; set; }
        public string provider_name { get; set; }
        public string thumbnail_url { get; set; }
        public int thumbnail_height { get; set; }
        public string author_url { get; set; }
    }

    public class Media
    {
        public Oembed2 oembed { get; set; }
        public string type { get; set; }
    }

    public class Data2
    {
        public string domain { get; set; }
        public object banned_by { get; set; }
        public MediaEmbed media_embed { get; set; }
        public string subreddit { get; set; }
        public string selftext_html { get; set; }
        public string selftext { get; set; }
        public object likes { get; set; }
        public List<object> user_reports { get; set; }
        public SecureMedia secure_media { get; set; }
        public string link_flair_text { get; set; }
        public string id { get; set; }
        public int gilded { get; set; }
        public SecureMediaEmbed secure_media_embed { get; set; }
        public bool clicked { get; set; }
        public object report_reasons { get; set; }
        public string author { get; set; }
        public Media media { get; set; }
        public int score { get; set; }
        public object approved_by { get; set; }
        public bool over_18 { get; set; }
        public bool hidden { get; set; }
        public string thumbnail { get; set; }
        public string subreddit_id { get; set; }
        public object edited { get; set; }
        public string link_flair_css_class { get; set; }
        public object author_flair_css_class { get; set; }
        public int downs { get; set; }
        public List<object> mod_reports { get; set; }
        public bool saved { get; set; }
        public bool is_self { get; set; }
        public string name { get; set; }
        public string permalink { get; set; }
        public bool stickied { get; set; }
        public int created { get; set; }
        public string url { get; set; }
        public object author_flair_text { get; set; }
        public string title { get; set; }
        public int created_utc { get; set; }
        public int ups { get; set; }
        public int num_comments { get; set; }
        public bool visited { get; set; }
        public object num_reports { get; set; }
        public object distinguished { get; set; }
    }

    public class Child
    {
        public string kind { get; set; }
        public Data2 data { get; set; }
    }

    public class Data
    {
        public string modhash { get; set; }
        public List<Child> children { get; set; }
        public string after { get; set; }
        public object before { get; set; }
    }

}
