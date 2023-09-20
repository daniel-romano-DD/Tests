using System;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Text.RegularExpressions;
using System.Text;
using System.Drawing;

namespace TestconsoleApp1 // Note: actual namespace depends on the project name.
{
	internal class HardcodedSecretsTest
	{
		public static int Main_(string[] args)
		{
			//return RegexGenerator.GenerateSecretRules().Count;

			Console.WriteLine();

			//generateSampleSecret("adafruit-api-key", "adafruit", secrets.NewSecret(alphaNumericExtendedShort("32"));
			//generateSampleSecret("adobe-client-id", "adobe", secrets.NewSecret(hex("32"));
			//generateSampleSecret("age", "AGE-SECRET-KEY-1QQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQ");
			//generateSampleSecret("airtable-api-key", "airtable", secrets.NewSecret(alphaNumeric("17"));
			//generateSampleSecret("algolia-api-key", "algolia_key := " + secrets.NewSecret(hex("32"));
			//generateSampleSecret("alibaba-access-key-id", "alibaba", "LTAI" + secrets.NewSecret(hex("20"));
			//generateSampleSecret("asana-client-id", "asana", secrets.NewSecret(numeric("16"));
			//generateSampleSecret("atlassian-api-token", "atlassian", secrets.NewSecret(alphaNumeric("24"));
			//generateSampleSecret("atlassian-api-token", "confluence", secrets.NewSecret(alphaNumeric("24"));
			//generateSampleSecret("authress-service-client-access-key", "authress", secrets.NewSecret($"sc_{alphaNumeric("10")}.{alphaNumeric("4")}.acc_{alphaNumeric("10")}.{alphaNumericExtendedShort("40")}"));
			//generateSampleSecret("aws-access-token", "AWS", "AKIALALEMEL33243OLIB");
			//generateSampleSecret("beamer-api-token", "beamer", "b_" + secrets.NewSecret(alphaNumericExtended("44"));
			//generateSampleSecret("bitbucket-client-id", "bitbucket", secrets.NewSecret(alphaNumeric("32"));
			//generateSampleSecret("bittrex-access-key", "bittrex", secrets.NewSecret(alphaNumeric("32"));
			//generateSampleSecret("clojars-api-token", "clojars", "CLOJARS_" + secrets.NewSecret(alphaNumeric("60"));
			//generateSampleSecret("codecov-access-token", "codecov", secrets.NewSecret(alphaNumeric("32"));
			//generateSampleSecret("coinbase-access-token", "coinbase", secrets.NewSecret(alphaNumericExtendedShort("64"));
			//generateSampleSecret("confluent-secret-key", "confluent", secrets.NewSecret(alphaNumeric("64"));
			//generateSampleSecret("contentful-delivery-api-token", "contentful", secrets.NewSecret(alphaNumeric("43"));
			//generateSampleSecret("databricks-api-token", "databricks", "dapi" + secrets.NewSecret(hex("32"));
			//generateSampleSecret("datadog-access-token", "datadog", secrets.NewSecret(alphaNumeric("40"));
			//generateSampleSecret("defined-networking-api-token", "dnkey", "dnkey-" + secrets.NewSecret(alphaNumericExtended("26")) + "-" + secrets.NewSecret(alphaNumericExtended("52"));
			//generateSampleSecret("digitalocean-pat", "do", "dop_v1_" + secrets.NewSecret(hex("64"));
			//generateSampleSecret("digitalocean-access-token", "do", "doo_v1_" + secrets.NewSecret(hex("64"));
			//generateSampleSecret("digitalocean-refresh-token", "do", "dor_v1_" + secrets.NewSecret(hex("64"));
			//generateSampleSecret("discord-api-token", "discord", secrets.NewSecret(hex("64"));
			//generateSampleSecret("discord-client-id", "discord", secrets.NewSecret(numeric("18"));
			//generateSampleSecret("discord-client-secret", "discord", secrets.NewSecret(numeric("32"));
			//generateSampleSecret("doppler-api-token", "doppler", "dp.pt." + secrets.NewSecret(alphaNumeric("43"));
			//generateSampleSecret("droneci-access-token", "droneci", secrets.NewSecret(alphaNumeric("32"));
			//generateSampleSecret("dropbox-api-token", "dropbox", secrets.NewSecret(alphaNumeric("15"));
			//generateSampleSecret("dropbox-short-lived-api-token", "dropbox", Reggen($"sl.{valuesa_z}{values0_9}-= _]", "135"));
			//generateSampleSecret("dropbox-long-lived-api-token", "dropbox", Reggen($"{valuesa_z}{values0_9}", "11") + Reggen("A", "10") + Reggen($"{valuesa_z}{values0_9}-_=]", "43"));
			//generateSampleSecret("duffel-api-token", "duffel", "duffel_test_" + secrets.NewSecret(alphaNumericExtended("43"));
			//generateSampleSecret("dynatrace-api-token", "dynatrace", "dt0c01." + secrets.NewSecret(alphaNumeric("24")) + "." + secrets.NewSecret(alphaNumeric("64"));
			//generateSampleSecret("easypost-api-token", "EZAK", "EZAK" + secrets.NewSecret(alphaNumeric("54"));
			//generateSampleSecret("easypost-test-api-token", "EZTK", "EZTK" + secrets.NewSecret(alphaNumeric("54"));
			//generateSampleSecret("etsy-access-token", "etsy", secrets.NewSecret(alphaNumeric("24"));



			//generateSampleSecret("aws-access-token", UniqueTokenRegex(@"(A3T[A-Z0-9]|AKIA|AGPA|AIDA|AROA|AIPA|ANPA|ANVA|ASIA)[A-Z0-9]{16}"));
			//generateSampleSecret("private-key", MustCompile(@"(?i)-----BEGIN[A-Z0-9_-]{0,100}PRIVATE KEY( BLOCK)?-----[\s\S-]*KEY( BLOCK)?----"));
			generateSampleSecret("generic-api-key", SemiGenericRegex(new string[] { "key", "api", "token", "secret", "client", "passwd", "password", "auth", "access" }, () => Reggen(@"[0-9a-z\-_.=]", 10, 150, true)));

			generateSampleSecret("adafruit-api-key", SemiGenericRegex(new string[] { "adafruit" }, () => AlphaNumericExtendedShort(32, true)));
			generateSampleSecret("adobe-client-id", SemiGenericRegex(new string[] { "adobe" }, () => Hex(32, true)));
			//generateSampleSecret("adobe-client-secret", UniqueTokenRegex("(p8e-)(?i)[a-z0-9]{32}", true));
			//generateSampleSecret("age-secret-key", MustCompile("AGE-SECRET-KEY-1[QPZRY9X8GF2TVDW0S3JN54KHCE6MUA7L]{58}"));
			generateSampleSecret("airtable-api-key", SemiGenericRegex(new string[] { "airtable" }, () => AlphaNumeric(17, true)));
			generateSampleSecret("algolia-api-key", SemiGenericRegex(new string[] { "algolia" }, () => Reggen("[a-z0-9]", 32, true)));
			//generateSampleSecret("alibaba-access-key-id", UniqueTokenRegex("(LTAI)(?i)[a-z0-9]{20}", true));
			generateSampleSecret("asana-client-id", SemiGenericRegex(new string[] { "asana" }, () => Numeric(16, true)));
			generateSampleSecret("asana-client-secret", SemiGenericRegex(new string[] { "asana" }, () => AlphaNumeric(32, true)));
			generateSampleSecret("atlassian-api-token", SemiGenericRegex(new string[] { "atlassian", "confluence", "jira" }, () => AlphaNumeric(24, true)));
			//generateSampleSecret("authress-service-client-access-key", UniqueTokenRegex(@"(?:sc|ext|scauth|authress)_[a-z0-9]{5,30}\.[a-z0-9]{4,6}\.acc[_-][a-z0-9-]{10,32}\.[a-z0-9+/_=-]{30,120}", true));
			generateSampleSecret("beamer-api-token", SemiGenericRegex(new string[] { "beamer" }, () => Reggen(@"b_[a-z0-9=_\-]{44}", true)));
			generateSampleSecret("bitbucket-client-id", SemiGenericRegex(new string[] { "bitbucket" }, () => AlphaNumeric(32, true)));
			generateSampleSecret("bitbucket-client-secret", SemiGenericRegex(new string[] { "bitbucket" }, () => AlphaNumericExtended(64, true)));
			generateSampleSecret("bittrex-access-key", SemiGenericRegex(new string[] { "bittrex" }, () => AlphaNumeric(32, true)));
			//generateSampleSecret("clojars-api-token", MustCompile(@"(?i)(CLOJARS_)[a-z0-9]{60}"));
			generateSampleSecret("codecov-access-token", SemiGenericRegex(new string[] { "codecov" }, () => AlphaNumeric(32, true)));
			generateSampleSecret("coinbase-access-token", SemiGenericRegex(new string[] { "coinbase" }, () => AlphaNumericExtendedShort(64, true)));
			generateSampleSecret("confluent-secret-key", SemiGenericRegex(new string[] { "confluent" }, () => AlphaNumeric(64, true)));
			generateSampleSecret("confluent-access-token", SemiGenericRegex(new string[] { "confluent" }, () => AlphaNumeric(16, true)));
			generateSampleSecret("contentful-delivery-api-token", SemiGenericRegex(new string[] { "contentful" }, () => AlphaNumericExtended(43, true)));
			//generateSampleSecret("databricks-api-token", UniqueTokenRegex("dapi[a-h0-9]{32}", true));
			generateSampleSecret("datadog-access-token", SemiGenericRegex(new string[] { "datadog" }, () => AlphaNumeric(40, true)));
			generateSampleSecret("defined-networking-api-token", SemiGenericRegex(new string[] { "dnkey" }, () => Reggen(@"dnkey-[a-z0-9=_\-]{26}-[a-z0-9=_\-]{52}", true)));
			//generateSampleSecret("digitalocean-pat", UniqueTokenRegex(@"dop_v1_[a-f0-9]{64}", true));
			//generateSampleSecret("digitalocean-access-token", UniqueTokenRegex(@"doo_v1_[a-f0-9]{64}", true));
			//generateSampleSecret("digitalocean-refresh-token", UniqueTokenRegex(@"dor_v1_[a-f0-9]{64}", true));
			generateSampleSecret("discord-api-token", SemiGenericRegex(new string[] { "discord" }, () => Hex(64, true)));
			generateSampleSecret("discord-client-id", SemiGenericRegex(new string[] { "discord" }, () => Numeric(18, true)));
			generateSampleSecret("discord-client-secret", SemiGenericRegex(new string[] { "discord" }, () => AlphaNumericExtended(32, true)));
			//generateSampleSecret("doppler-api-token", MustCompile(@"(dp\.pt\.)(?i)[a-z0-9]{43}"));
			generateSampleSecret("droneci-access-token", SemiGenericRegex(new string[] { "droneci" }, () => AlphaNumeric(32, true)));
			generateSampleSecret("dropbox-api-token", SemiGenericRegex(new string[] { "dropbox" }, () => AlphaNumeric(15, true)));
			generateSampleSecret("dropbox-short-lived-api-token", SemiGenericRegex(new string[] { "dropbox" }, () => Reggen(@"sl\.[a-z0-9\-=_]{135}", true)));
			generateSampleSecret("dropbox-long-lived-api-token", SemiGenericRegex(new string[] { "dropbox" }, () => Reggen(@"[a-z0-9]{11}AAAAAAAAAA[a-z0-9\-_=]{43}", true)));
			//generateSampleSecret("duffel-api-token", MustCompile(@"duffel_(test|live)_(?i)[a-z0-9_\-=]{43}"));
			//generateSampleSecret("dynatrace-api-token", MustCompile(@"dt0c01\.(?i)[a-z0-9]{24}\.[a-z0-9]{64}"));
			//generateSampleSecret("easypost-api-token", MustCompile(@"\bEZAK(?i)[a-z0-9]{54}"));
			generateSampleSecret("etsy-access-token", SemiGenericRegex(new string[] { "etsy" }, () => AlphaNumeric(24, true)));
			generateSampleSecret("facebook", SemiGenericRegex(new string[] { "facebook" }, () => Hex(32, true)));
			generateSampleSecret("fastly-api-token", SemiGenericRegex(new string[] { "fastly" }, () => AlphaNumericExtended(32, true)));
			generateSampleSecret("finicity-client-secret", SemiGenericRegex(new string[] { "finicity" }, () => AlphaNumeric(20, true)));
			generateSampleSecret("finicity-api-token", SemiGenericRegex(new string[] { "finicity" }, () => Hex(32, true)));
			generateSampleSecret("finnhub-access-token", SemiGenericRegex(new string[] { "finnhub" }, () => AlphaNumeric(20, true)));
			generateSampleSecret("flickr-access-token", SemiGenericRegex(new string[] { "flickr" }, () => AlphaNumeric(32, true)));
			//generateSampleSecret("flutterwave-public-key", MustCompile(@"FLWPUBK_TEST-(?i)[a-h0-9]{32}-X"));
			//generateSampleSecret("frameio-api-token", MustCompile(@"fio-u-(?i)[a-z0-9\-_=]{64}"));
			generateSampleSecret("freshbooks-access-token", SemiGenericRegex(new string[] { "freshbooks" }, () => AlphaNumeric(64, true)));
			//generateSampleSecret("gcp-api-key", UniqueTokenRegex(@"AIza[0-9A-Za-z\-_]{35}", true));
			//generateSampleSecret("github-pat", MustCompile(@"ghp_[0-9a-zA-Z]{36}"));
			//generateSampleSecret("github-fine-grained-pat", MustCompile(@"github_pat_[0-9a-zA-Z_]{82}"));
			//generateSampleSecret("github-oauth", MustCompile(@"gho_[0-9a-zA-Z]{36}"));
			//generateSampleSecret("github-app-token", MustCompile(@"(ghu|ghs)_[0-9a-zA-Z]{36}"));
			//generateSampleSecret("gitlab-pat", MustCompile(@"glpat-[0-9a-zA-Z\-\_]{20}"));
			//generateSampleSecret("gitlab-ptt", MustCompile(@"glptt-[0-9a-f]{40}"));
			//generateSampleSecret("gitlab-rrt", MustCompile(@"GR1348941[0-9a-zA-Z\-\_]{20}"));
			generateSampleSecret("gitter-access-token", SemiGenericRegex(new string[] { "gitter" }, () => AlphaNumericExtendedShort(40, true)));
			generateSampleSecret("gocardless-api-token", SemiGenericRegex(new string[] { "gocardless" }, () => Reggen(@"live_(?i)[a-z0-9\-_=]{40}", true)));
			//generateSampleSecret("grafana-api-key", UniqueTokenRegex(@"eyJrIjoi[A-Za-z0-9]{70,400}={0,2}", true));
			//generateSampleSecret("grafana-cloud-api-token", UniqueTokenRegex(@"glc_[A-Za-z0-9+/]{32,400}={0,2}", true));
			//generateSampleSecret("grafana-service-account-token", UniqueTokenRegex(@"glsa_[A-Za-z0-9]{32}_[A-Fa-f0-9]{8}", true));
			//generateSampleSecret("hashicorp-tf-api-token", MustCompile(@"(?i)[a-z0-9]{14}\.atlasv1\.[a-z0-9\-_=]{60,70}"));
			generateSampleSecret("heroku-api-key", SemiGenericRegex(new string[] { "heroku" }, () => Hex8_4_4_4_12()));
			generateSampleSecret("hubspot-api-key", SemiGenericRegex(new string[] { "hubspot" }, () => Reggen(@"[0-9A-F]{8}-[0-9A-F]{4}-[0-9A-F]{4}-[0-9A-F]{4}-[0-9A-F]{12}", true)));
			generateSampleSecret("intercom-api-key", SemiGenericRegex(new string[] { "intercom" }, () => AlphaNumericExtended(60, true)));
			generateSampleSecret("jfrog-api-key", SemiGenericRegex(new string[] { "jfrog", "artifactory", "bintray", "xray" }, () => AlphaNumeric(73, true)));
			//generateSampleSecret("jwt", UniqueTokenRegex(@"ey[a-zA-Z0-9]{17,}\.ey[a-zA-Z0-9\/\_-]{17,}\.(?:[a-zA-Z0-9\/\_-]{10,}={0,2})?", false));
			//generateSampleSecret("jwt-base64", MustCompile(@"\bZXlK(?:(?P<alg>aGJHY2lPaU)|(?P<apu>aGNIVWlPaU)|(?P<apv>aGNIWWlPaU)|(?P<aud>aGRXUWlPaU)|(?P<b64>aU5qUWlP)|(?P<crit>amNtbDBJanBi)|(?P<cty>amRIa2lPaU)|(?P<epk>bGNHc2lPbn)|(?P<enc>bGJtTWlPaU)|(?P<jku>cWEzVWlPaU)|(?P<jwk>cWQyc2lPb)|(?P<iss>cGMzTWlPaU)|(?P<iv>cGRpSTZJ)|(?P<kid>cmFXUWlP)|(?P<key_ops>clpYbGZiM0J6SWpwY)|(?P<kty>cmRIa2lPaUp)|(?P<nonce>dWIyNWpaU0k2)|(?P<p2c>d01tTWlP)|(?P<p2s>d01uTWlPaU)|(?P<ppt>d2NIUWlPaU)|(?P<sub>emRXSWlPaU)|(?P<svt>emRuUWlP)|(?P<tag>MFlXY2lPaU)|(?P<typ>MGVYQWlPaUp)|(?P<url>MWNtd2l)|(?P<use>MWMyVWlPaUp)|(?P<ver>MlpYSWlPaU)|(?P<version>MlpYSnphVzl1SWpv)|(?P<x>NElqb2)|(?P<x5c>NE5XTWlP)|(?P<x5t>NE5YUWlPaU)|(?P<x5ts256>NE5YUWpVekkxTmlJNkl)|(?P<x5u>NE5YVWlPaU)|(?P<zip>NmFYQWlPaU))[a-zA-Z0-9\/\_+\-\r\n]{40,}={0,2}"));
			//	generateSampleSecret("kraken-access-token", SemiGenericRegex(new string[] { "kraken" }, () => AlphaNumericExtendedLong("80,90", true)));
			generateSampleSecret("kucoin-access-token", SemiGenericRegex(new string[] { "kucoin" }, () => Hex(24, true)));
			generateSampleSecret("launchdarkly-access-token", SemiGenericRegex(new string[] { "launchdarkly" }, () => AlphaNumericExtended(40, true)));
			//generateSampleSecret("linear-api-key", MustCompile(@"lin_api_(?i)[a-z0-9]{40}"));
			generateSampleSecret("linkedin-client-secret", SemiGenericRegex(new string[] { "linkedin", "linked-in" }, () => AlphaNumeric(16, true)));
			generateSampleSecret("lob-pub-api-key", SemiGenericRegex(new string[] { "lob" }, () => Reggen(@"live_pub_[a-f0-9]{31}", true)));
			generateSampleSecret("lob-pub-api-key", SemiGenericRegex(new string[] { "lob" }, () => Reggen(@"test_pub_[a-f0-9]{31}", true)));
			generateSampleSecret("mailchimp-api-key", SemiGenericRegex(new string[] { "mailchimp" }, () => Reggen(@"[a-f0-9]{32}-us20", true)));
			generateSampleSecret("mailgun-private-api-token", SemiGenericRegex(new string[] { "mailgun" }, () => Reggen(@"key-[a-f0-9]{32}", true)));
			generateSampleSecret("mailgun-pub-key", SemiGenericRegex(new string[] { "mailgun" }, () => Reggen(@"pubkey-[a-f0-9]{32}", true)));
			generateSampleSecret("mailgun-signing-key", SemiGenericRegex(new string[] { "mailgun" }, () => Reggen(@"[a-h0-9]{32}-[a-h0-9]{8}-[a-h0-9]{8}", true)));
			generateSampleSecret("mapbox-api-token", SemiGenericRegex(new string[] { "mapbox" }, () => Reggen(@"pk\.[a-z0-9]{60}\.[a-z0-9]{22}", true)));
			generateSampleSecret("mattermost-access-token", SemiGenericRegex(new string[] { "mattermost" }, () => AlphaNumeric(26, true)));
			generateSampleSecret("messagebird-api-token", SemiGenericRegex(new string[] { "messagebird", "message-bird", "message_bird" }, () => AlphaNumeric(25, true)));
		//	generateSampleSecret("netlify-access-token", SemiGenericRegex(new string[] { "netlify" }, () => AlphaNumericExtended("40,46", true)));
			generateSampleSecret("new-relic-user-api-key", SemiGenericRegex(new string[] { "new-relic", "newrelic", "new_relic" }, () => Reggen(@"NRAK-[a-z0-9]{27}", true)));
			generateSampleSecret("new-relic-user-api-id", SemiGenericRegex(new string[] { "new-relic", "newrelic", "new_relic" }, () => AlphaNumeric(64, true)));
			generateSampleSecret("new-relic-browser-api-token", SemiGenericRegex(new string[] { "new-relic", "newrelic", "new_relic" }, () => Reggen(@"NRJS-[a-f0-9]{19}", true)));
			//generateSampleSecret("npm-access-token", UniqueTokenRegex(@"npm_[a-z0-9]{36}", true));
			generateSampleSecret("nytimes-access-token", SemiGenericRegex(new string[] { "nytimes", "new-york-times,", "newyorktimes" }, () => AlphaNumericExtended(32, true)));
			generateSampleSecret("okta-access-token", SemiGenericRegex(new string[] { "okta" }, () => AlphaNumericExtended(42, true)));
			//generateSampleSecret("openai-api-key", UniqueTokenRegex(@"sk-[a-zA-Z0-9]{20}T3BlbkFJ[a-zA-Z0-9]{20}", true));
			generateSampleSecret("plaid-client-id", SemiGenericRegex(new string[] { "plaid" }, () => AlphaNumeric(24, true)));
			generateSampleSecret("plaid-secret-key", SemiGenericRegex(new string[] { "plaid" }, () => AlphaNumeric(30, true)));
			generateSampleSecret("plaid-api-token", SemiGenericRegex(new string[] { "plaid" }, () => Reggen($"access-sandbox-{Hex8_4_4_4_12()}", true)));
			generateSampleSecret("plaid-api-token", SemiGenericRegex(new string[] { "plaid" }, () => Reggen($"access-development-{Hex8_4_4_4_12()}", true)));
			generateSampleSecret("plaid-api-token", SemiGenericRegex(new string[] { "plaid" }, () => Reggen($"access-production-{Hex8_4_4_4_12()}", true)));
			//generateSampleSecret("planetscale-password", UniqueTokenRegex(@"pscale_pw_(?i)[a-z0-9=\-_\.]{32,64}", true));
			//generateSampleSecret("planetscale-api-token", UniqueTokenRegex(@"pscale_tkn_(?i)[a-z0-9=\-_\.]{32,64}", true));
			//generateSampleSecret("planetscale-oauth-token", UniqueTokenRegex(@"pscale_oauth_(?i)[a-z0-9=\-_\.]{32,64}", true));
			//generateSampleSecret("postman-api-token", UniqueTokenRegex(@"PMAK-(?i)[a-f0-9]{24}\-[a-f0-9]{34}", true));
			//generateSampleSecret("prefect-api-token", UniqueTokenRegex(@"pnu_[a-z0-9]{36}", true));
			//generateSampleSecret("pulumi-api-token", UniqueTokenRegex(@"pul-[a-f0-9]{40}", true));
			//generateSampleSecret("pypi-upload-token", MustCompile(@"pypi-AgEIcHlwaS5vcmc[A-Za-z0-9\-_]{50,1000}"));
			generateSampleSecret("rapidapi-access-token", SemiGenericRegex(new string[] { "rapidapi" }, () => AlphaNumericExtendedShort(50, true)));
			//generateSampleSecret("readme-api-token", UniqueTokenRegex(@"rdme_[a-z0-9]{70}", true));
			//generateSampleSecret("rubygems-api-token", UniqueTokenRegex(@"rubygems_[a-f0-9]{48}", true));
			//generateSampleSecret("scalingo-api-token", MustCompile(@"\btk-us-[a-zA-Z0-9-_]{48}\b"));
			generateSampleSecret("sendbird-access-token", SemiGenericRegex(new string[] { "sendbird" }, () => Hex(40, true)));
			generateSampleSecret("sendbird-access-id", SemiGenericRegex(new string[] { "sendbird" }, () => Hex8_4_4_4_12()));
			//generateSampleSecret("sendgrid-api-token", UniqueTokenRegex(@"SG\.(?i)[a-z0-9=_\-\.]{66}", true));
			//generateSampleSecret("sendinblue-api-token", UniqueTokenRegex(@"xkeysib-[a-f0-9]{64}\-(?i)[a-z0-9]{16}", true));
			generateSampleSecret("sentry-access-token", SemiGenericRegex(new string[] { "sentry" }, () => Hex(64, true)));
			//generateSampleSecret("shippo-api-token", UniqueTokenRegex(@"shippo_(live|test)_[a-f0-9]{40}", true));
			//generateSampleSecret("shopify-shared-secret", MustCompile(@"shpss_[a-fA-F0-9]{32}"));
			//generateSampleSecret("shopify-access-token", MustCompile(@"shpat_[a-fA-F0-9]{32}"));
			//generateSampleSecret("shopify-custom-access-token", MustCompile(@"shpca_[a-fA-F0-9]{32}"));
			//generateSampleSecret("shopify-private-app-access-token", MustCompile(@"shppa_[a-fA-F0-9]{32}"));
			generateSampleSecret("sidekiq-secret", SemiGenericRegex(new string[] { "BUNDLE_ENTERPRISE__CONTRIBSYS__COM", "BUNDLE_GEMS__CONTRIBSYS__COM" }, () => Reggen(@"[a-f0-9]{8}:[a-f0-9]{8}", true)));
			//generateSampleSecret("sidekiq-sensitive-url", MustCompile(@"(?i)\b(http(?:s??):\/\/)([a-f0-9]{8}:[a-f0-9]{8})@(?:gems.contribsys.com|enterprise.contribsys.com)(?:[\/|\#|\?|:]|$)"));
			//generateSampleSecret("slack-bot-token", MustCompile(@"(xoxb-[0-9]{10,13}\-[0-9]{10,13}[a-zA-Z0-9-]*)"));
			//generateSampleSecret("slack-user-token", MustCompile(@"(xox[pe](?:-[0-9]{10,13}){3}-[a-zA-Z0-9-]{28,34})"));
			//generateSampleSecret("slack-app-token", MustCompile(@"(?i)(xapp-\d-[A-Z0-9]+-\d+-[a-z0-9]+)"));
			//generateSampleSecret("slack-config-access-token", MustCompile(@"(?i)(xoxe.xox[bp]-\d-[A-Z0-9]{163,166})"));
			//generateSampleSecret("slack-config-refresh-token", MustCompile(@"(?i)(xoxe-\d-[A-Z0-9]{146})"));
			//generateSampleSecret("slack-legacy-bot-token", MustCompile(@"(xoxb-[0-9]{8,14}\-[a-zA-Z0-9]{18,26})"));
			//generateSampleSecret("slack-legacy-workspace-token", MustCompile(@"(xox[ar]-(?:\d-)?[0-9a-zA-Z]{8,48})"));
			//generateSampleSecret("slack-legacy-token", MustCompile(@"(xox[os]-\d+-\d+-\d+-[a-fA-F\d]+)"));
			//generateSampleSecret("slack-webhook-url", MustCompile(@"(https?:\/\/)?hooks.slack.com\/(services|workflows)\/[A-Za-z0-9+\/]{43,46}"));
			generateSampleSecret("snyk-api-token", SemiGenericRegex(new string[] { "snyk" }, () => Hex8_4_4_4_12()));
			//generateSampleSecret("square-access-token", UniqueTokenRegex(@"sq0atp-[0-9A-Za-z\-_]{22}", true));
			//generateSampleSecret("square-secret", UniqueTokenRegex(@"sq0csp-[0-9A-Za-z\-_]{43}", true));
			generateSampleSecret("squarespace-access-token", SemiGenericRegex(new string[] { "squarespace" }, () => Hex8_4_4_4_12()));
			//generateSampleSecret("stripe-access-token", MustCompile(@"(?i)(sk|pk)_(test|live)_[0-9a-z]{10,32}"));
			generateSampleSecret("sumologic-access-token", SemiGenericRegex(new string[] { "sumo" }, () => AlphaNumeric(64, true)));
			//generateSampleSecret("microsoft-teams-webhook", MustCompile(@"https:\/\/[a-z0-9]+\.webhook\.office\.com\/webhookb2\/[a-z0-9]{8}-([a-z0-9]{4}-){3}[a-z0-9]{12}@[a-z0-9]{8}-([a-z0-9]{4}-){3}[a-z0-9]{12}\/IncomingWebhook\/[a-z0-9]{32}\/[a-z0-9]{8}-([a-z0-9]{4}-){3}[a-z0-9]{12}"));
			//generateSampleSecret("telegram-bot-api-token", MustCompile(@"(?i)(?:^|[^0-9])([0-9]{5,16}:A[a-zA-Z0-9_\-]{34})(?:$|[^a-zA-Z0-9_\-])"));
			generateSampleSecret("travisci-access-token", SemiGenericRegex(new string[] { "travis" }, () => AlphaNumeric(22, true)));
			generateSampleSecret("trello-access-token", SemiGenericRegex(new string[] { "trello" }, () => Reggen(@"[a-zA-Z-0-9]{32}", true)));
			//generateSampleSecret("twilio-api-key", MustCompile(@"SK[0-9a-fA-F]{32}"));
			generateSampleSecret("twitch-api-token", SemiGenericRegex(new string[] { "twitch" }, () => AlphaNumeric(30, true)));
			generateSampleSecret("twitter-api-key", SemiGenericRegex(new string[] { "twitter" }, () => AlphaNumeric(25, true)));
			generateSampleSecret("twitter-api-secret", SemiGenericRegex(new string[] { "twitter" }, () => AlphaNumeric(50, true)));
			generateSampleSecret("twitter-bearer-token", SemiGenericRegex(new string[] { "twitter" }, () => Reggen("[A]{22}[a-zA-Z0-9%]{80,100}", true)));
			generateSampleSecret("twitter-access-token", SemiGenericRegex(new string[] { "twitter" }, () => Reggen("[0-9]{15,25}-[a-zA-Z0-9]{20,40}", true)));
			generateSampleSecret("twitter-access-secret", SemiGenericRegex(new string[] { "twitter" }, () => AlphaNumeric(45, true)));
			generateSampleSecret("typeform-api-token", SemiGenericRegex(new string[] { "typeform" }, () => Reggen(@"tfp_[a-z0-9\-_\.=]{59}", true)));
			//generateSampleSecret("vault-service-token", UniqueTokenRegex(@"hvs\.[a-z0-9_-]{90,100}", true));
			//generateSampleSecret("vault-batch-token", UniqueTokenRegex(@"hvb\.[a-z0-9_-]{138,212}", true));
			generateSampleSecret("yandex-aws-access-token", SemiGenericRegex(new string[] { "yandex" }, () => Reggen(@"YC[a-zA-Z0-9_\-]{38}", true)));
			generateSampleSecret("yandex-api-key", SemiGenericRegex(new string[] { "yandex" }, () => Reggen(@"AQVN[A-Za-z0-9_\-]{35,38}", true)));
			generateSampleSecret("yandex-access-token", SemiGenericRegex(new string[] { "yandex" }, () => Reggen(@"t1\.[A-Z0-9a-z_-]{1,10}[=]{0,2}\.[A-Z0-9a-z_-]{86}[=]{0,2}", true)));
			generateSampleSecret("zendesk-secret-key", SemiGenericRegex(new string[] { "zendesk" }, () => AlphaNumeric(40, true)));




			return 0;
		}

		static void generateSampleSecret(string rule, params string[] secrets)
		{
			foreach (var secret in secrets)
			{
				Console.WriteLine($"[InlineData(\"{rule}\", @\"{secret}\")]");
			}
		}
		static void generateSampleSecret(string rule, string key, string secret)
		{
			Console.WriteLine($"[InlineData(\"{rule}\", @\"{key} = {secret}\")]");
		}


		//private static class secrets
		//{
		//	public static string NewSecret(string secret) { return secret; }
		//}

		// case insensitive prefix
		private const string CaseInsensitive = @"(?i)";

		// identifier prefix (just an ignore group)
		private const string IdentifierCaseInsensitivePrefix = @"(?i:";
		private const string IdentifierCaseInsensitiveSuffix = @")";

		private const string IdentifierPrefix = @"(?:";
		private const string IdentifierSuffix = @")(?:[0-9a-z\-_\t.]{0,20})(?:[\s|']|[\s|""]){0,3}";

		// commonly used assignment operators or function call
		private const string Operator = @"(?:=|>|:{1,3}=|\|\|:|<=|=>|:|\?=)";

		// boundaries for the secret
		// \x60 = "
		private const string SecretPrefixUnique = @"\b(";
		private const string SecretPrefix = @"(?:'|\""|\s|=|\x60){0,5}(";
		private const string SecretSuffix = @")(?:['|\""|\n|\r|\s|\x60|;]|$)";

		public static string UniqueTokenRegex(string secretRegex, bool isCaseInsensitive = false)
		{
			return secretRegex;
			//var sb = new StringBuilder();

			//if (isCaseInsensitive)
			//{
			//	sb.Append(CaseInsensitive);
			//}

			//sb.Append(SecretPrefixUnique);
			//sb.Append(secretRegex);
			//sb.Append(SecretSuffix);

			//return new Regex(sb.ToString(), RegexOptions.Compiled);
		}

		public static string[] SemiGenericRegex(string[] identifiers, Func<string> secretRegex)
		{
			List<string> res = new List<string>();
			foreach (var id in identifiers)
			{ 
				res.Add($"{id} = {secretRegex()}");
			}

			return res.ToArray();
		}

		private static void WriteIdentifiers(StringBuilder sb, string[] identifiers)
		{
			sb.Append(IdentifierPrefix);
			sb.Append(string.Join("|", identifiers));
			sb.Append(IdentifierSuffix);
		}

		public static string Numeric(int size, bool caseInsensitive)
		{
			// if (!secret) return $"[0-9]{size}";
			return Reggen(values0_9, size, caseInsensitive);
		}

		public static string Hex(int size, bool caseInsensitive)
		{
			// if (!secret) return $"[a-f0-9]{size}";
			return Reggen(valuesa_f + values0_9, size, caseInsensitive);
		}

		public static string AlphaNumeric(int size, bool caseInsensitive)
		{
			// if (!secret) return $"[a-z0-9]{size}";
			return Reggen(valuesa_z + values0_9, size, caseInsensitive);
		}

		public static string AlphaNumericExtendedShort(int size, bool caseInsensitive)
		{
			// if (!secret) return $"[a-z0-9_-]{size}";
			return Reggen(valuesa_z + values0_9 + "_-", size, caseInsensitive);
		}

		public static string AlphaNumericExtended(int size, bool caseInsensitive)
		{
			// if (!secret) return $"[a-z0-9=_\-]{size}";
			return Reggen(valuesa_z + values0_9 + "=_-", size, caseInsensitive);
		}

		public static string AlphaNumericExtendedLong(int size, bool caseInsensitive)
		{
			// if (!secret) return $"[a-z0-9\\/=_\\+\-]{size}";
			return Reggen(@"[a-z0-9\\/=_\+\-]{size}", caseInsensitive);
		}

		public static string Hex8_4_4_4_12()
		{
			//return "[0-9a-f]{8}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{12}";
			return Reggen("[0-9a-f]{8}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{12}");
		}

		const string values0_9 = "0123456789";
		const string valuesa_f = "abcdef";
		const string valuesA_F = "ABCDEF";
		const string valuesa_h = "abcdefgh";
		const string valuesa_z = "abcdefghijklmnopqrstuvwxyz";
		const string valuesA_Z = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

		static Random random = new Random((int)DateTime.UtcNow.Ticks);


		public static string Reggen(string pattern, bool caseInsensitive = true)
		{
			var evaluator = new MatchEvaluator(GroupProcessor);
			var res = Regex.Replace(pattern, @"(\[[^\{]+\])\{(\d+)(?:,(\d+))?\}?", evaluator, RegexOptions.IgnorePatternWhitespace);
			res = res.Replace("\\s", " ").Replace("\\", "").Replace("(?i)", "");
			return res;
		}
		static string GroupProcessor(Match m)
		{
			if (m.Groups.Count == 1) { return m.Value; }
			var pattern = m.Groups[1].ToString();
			int min = Convert.ToInt32(m.Groups[2].ToString());
			int max = min;
			var g3 = m.Groups[3].ToString();
			if(g3 != "") { max = Convert.ToInt32(g3); }

			return Reggen(pattern, min, max);
		}


		public static string Reggen(string pattern, int min, bool caseInsensitive = false)
		{
			return Reggen(pattern, min, min, caseInsensitive);
		}
		public static string Reggen(string pattern, int min, int max, bool caseInsensitive = false)
		{
			if (max < min) { max = min; }
			var size = random.Next(min, max + 1);
			var sb = new StringBuilder(size);

			pattern = Process(pattern);

			for (int x = 0; x < size; x++)
			{ 
				int index = random.Next(0, pattern.Length);
				if (!caseInsensitive && random.Next(2) == 0)
				{
					sb.Append(char.ToUpperInvariant(pattern[index]));
				}
				else 
				{
					sb.Append(pattern[index]);
				}
			}
			return sb.ToString();
		}

		static string Process(string pattern)
		{
			var evaluator = new MatchEvaluator(RangeProcessor);
			var res = Regex.Replace(pattern, @"\[(?:(\w-\w)|(.+))+\]", evaluator, RegexOptions.IgnorePatternWhitespace);
			res = res.Replace(@"\-", "-");
			return res;
		}

		static string RangeProcessor(Match m)
		{
			var sb = new StringBuilder();
			foreach(var group in m.Groups) 
			{
				if (group == null || group.ToString() == m.Value) { continue; }
				sb.Append(RangeProcessor(group.ToString()));
			}
			return sb.ToString();
		}

		static string RangeProcessor(string m)
		{
			var res = m switch
			{
				"0-9" => values0_9,
				"a-z" => valuesa_z,
				"A-Z" => valuesA_Z,
				"a-f" => valuesa_f,
				"A-F" => valuesA_F,
				"a-h" => valuesa_h,
				_ => m.Replace("\\s", " ").Replace("\\", ""),
			};

			return res;
		}

	}


	static class RegexGenerator
	{
		public struct SecretRegex
		{
			public string Rule;
			public Regex Regex;

			public SecretRegex(string rule, Regex regex)
			{
				Rule = rule;
				Regex = regex;

				Console.WriteLine($"res.Add(new SecretRegex(\"{rule}\", @\"{regex.ToString().Replace("\"", "\"\"").Replace(@"\""""", @"""""")}\"));");
			}
		}


		// case insensitive prefix
		private const string CaseInsensitive = @"(?i)";

		// identifier prefix (just an ignore group)
		private const string IdentifierCaseInsensitivePrefix = @"(?i:";
		private const string IdentifierCaseInsensitiveSuffix = @")";

		private const string IdentifierPrefix = @"(?:";
		private const string IdentifierSuffix = @")(?:[0-9a-z\-_\t.]{0,20})(?:[\s|']|[\s|""]){0,3}";

		// commonly used assignment operators or function call
		private const string Operator = @"(?:=|>|:{1,3}=|\|\|:|<=|=>|:|\?=)";

		// boundaries for the secret
		// \x60 = "
		private const string SecretPrefixUnique = @"\b(";
		private const string SecretPrefix = @"(?:'|\""|\s|=|\x60){0,5}(";
		private const string SecretSuffix = @")(?:['|\""|\n|\r|\s|\x60|;]|$)";

		internal static List<SecretRegex> GenerateSecretRules()
		{
			var res = new List<SecretRegex>();

			// res.Add(new SecretRegex("github-app-token", UniqueTokenRegex(@"(ghu|ghs)_[0-9a-zA-Z]{36}")));
			res.Add(new SecretRegex("aws-access-token", UniqueTokenRegex(@"(A3T[A-Z0-9]|AKIA|AGPA|AIDA|AROA|AIPA|ANPA|ANVA|ASIA)[A-Z0-9]{16}")));
			res.Add(new SecretRegex("private-key", MustCompile(@"(?i)-----BEGIN[ A-Z0-9_-]{0,100}PRIVATE KEY( BLOCK)?-----[\s\S-]*KEY( BLOCK)?----")));

			res.Add(new SecretRegex("generic-api-key", SemiGenericRegex(new string[] { "key", "api", "token", "secret", "client", "passwd", "password", "auth", "access" }, @"[0-9a-z\-_.=]{10,150}", true)));

			res.Add(new SecretRegex("adafruit-api-key", SemiGenericRegex(new string[] { "adafruit" }, AlphaNumericExtendedShort(32), true)));
			res.Add(new SecretRegex("adobe-client-id", SemiGenericRegex(new string[] { "adobe" }, Hex(32), true)));
			res.Add(new SecretRegex("adobe-client-secret", UniqueTokenRegex("(p8e-)(?i)[a-z0-9]{32}", true)));
			res.Add(new SecretRegex("age-secret-key", MustCompile("AGE-SECRET-KEY-1[QPZRY9X8GF2TVDW0S3JN54KHCE6MUA7L]{58}")));
			res.Add(new SecretRegex("airtable-api-key", SemiGenericRegex(new string[] { "airtable" }, AlphaNumeric(17), true)));
			res.Add(new SecretRegex("algolia-api-key", SemiGenericRegex(new string[] { "algolia" }, "[a-z0-9]{32}", true)));
			res.Add(new SecretRegex("alibaba-access-key-id", UniqueTokenRegex("(LTAI)(?i)[a-z0-9]{20}", true)));
			res.Add(new SecretRegex("asana-client-id", SemiGenericRegex(new string[] { "asana" }, Numeric(16), true)));
			res.Add(new SecretRegex("asana-client-secret", SemiGenericRegex(new string[] { "asana" }, AlphaNumeric(32), true)));
			res.Add(new SecretRegex("atlassian-api-token", SemiGenericRegex(new string[] { "atlassian", "confluence", "jira" }, AlphaNumeric(24), true)));
			res.Add(new SecretRegex("authress-service-client-access-key", UniqueTokenRegex(@"(?:sc|ext|scauth|authress)_[a-z0-9]{5,30}\.[a-z0-9]{4,6}\.acc[_-][a-z0-9-]{10,32}\.[a-z0-9+/_=-]{30,120}", true)));
			res.Add(new SecretRegex("beamer-api-token", SemiGenericRegex(new string[] { "beamer" }, @"b_[a-z0-9=_\-]{44}", true)));
			res.Add(new SecretRegex("bitbucket-client-id", SemiGenericRegex(new string[] { "bitbucket" }, AlphaNumeric(32), true)));
			res.Add(new SecretRegex("bitbucket-client-secret", SemiGenericRegex(new string[] { "bitbucket" }, AlphaNumericExtended(64), true)));
			res.Add(new SecretRegex("bittrex-access-key", SemiGenericRegex(new string[] { "bittrex" }, AlphaNumeric(32), true)));
			res.Add(new SecretRegex("clojars-api-token", MustCompile(@"(?i)(CLOJARS_)[a-z0-9]{60}")));
			res.Add(new SecretRegex("codecov-access-token", SemiGenericRegex(new string[] { "codecov" }, AlphaNumeric(32), true)));
			res.Add(new SecretRegex("coinbase-access-token", SemiGenericRegex(new string[] { "coinbase" }, AlphaNumericExtendedShort(64), true)));
			res.Add(new SecretRegex("confluent-secret-key", SemiGenericRegex(new string[] { "confluent" }, AlphaNumeric(64), true)));
			res.Add(new SecretRegex("confluent-access-token", SemiGenericRegex(new string[] { "confluent" }, AlphaNumeric(16), true)));
			res.Add(new SecretRegex("contentful-delivery-api-token", SemiGenericRegex(new string[] { "contentful" }, AlphaNumericExtended(43), true)));
			res.Add(new SecretRegex("databricks-api-token", UniqueTokenRegex("dapi[a-h0-9]{32}", true)));
			res.Add(new SecretRegex("datadog-access-token", SemiGenericRegex(new string[] { "datadog" }, AlphaNumeric(40), true)));
			res.Add(new SecretRegex("defined-networking-api-token", SemiGenericRegex(new string[] { "dnkey" }, @"dnkey-[a-z0-9=_\-]{26}-[a-z0-9=_\-]{52}", true)));
			res.Add(new SecretRegex("digitalocean-pat", UniqueTokenRegex(@"dop_v1_[a-f0-9]{64}", true)));
			res.Add(new SecretRegex("digitalocean-access-token", UniqueTokenRegex(@"doo_v1_[a-f0-9]{64}", true)));
			res.Add(new SecretRegex("digitalocean-refresh-token", UniqueTokenRegex(@"dor_v1_[a-f0-9]{64}", true)));
			res.Add(new SecretRegex("discord-api-token", SemiGenericRegex(new string[] { "discord" }, Hex(64), true)));
			res.Add(new SecretRegex("discord-client-id", SemiGenericRegex(new string[] { "discord" }, Numeric(18), true)));
			res.Add(new SecretRegex("discord-client-secret", SemiGenericRegex(new string[] { "discord" }, AlphaNumericExtended(32), true)));
			res.Add(new SecretRegex("doppler-api-token", MustCompile(@"(dp\.pt\.)(?i)[a-z0-9]{43}")));
			res.Add(new SecretRegex("droneci-access-token", SemiGenericRegex(new string[] { "droneci" }, AlphaNumeric(32), true)));
			res.Add(new SecretRegex("dropbox-api-token", SemiGenericRegex(new string[] { "dropbox" }, AlphaNumeric(15), true)));
			res.Add(new SecretRegex("dropbox-short-lived-api-token", SemiGenericRegex(new string[] { "dropbox" }, @"sl\.[a-z0-9\-=_]{135}", true)));
			res.Add(new SecretRegex("dropbox-long-lived-api-token", SemiGenericRegex(new string[] { "dropbox" }, @"[a-z0-9]{11}(AAAAAAAAAA)[a-z0-9\-_=]{43}", true)));
			res.Add(new SecretRegex("duffel-api-token", MustCompile(@"duffel_(test|live)_(?i)[a-z0-9_\-=]{43}")));
			res.Add(new SecretRegex("dynatrace-api-token", MustCompile(@"dt0c01\.(?i)[a-z0-9]{24}\.[a-z0-9]{64}")));
			res.Add(new SecretRegex("easypost-api-token", MustCompile(@"\bEZAK(?i)[a-z0-9]{54}")));
			res.Add(new SecretRegex("etsy-access-token", SemiGenericRegex(new string[] { "etsy" }, AlphaNumeric(24), true)));
			res.Add(new SecretRegex("facebook", SemiGenericRegex(new string[] { "facebook" }, Hex(32), true)));
			res.Add(new SecretRegex("fastly-api-token", SemiGenericRegex(new string[] { "fastly" }, AlphaNumericExtended(32), true)));
			res.Add(new SecretRegex("finicity-client-secret", SemiGenericRegex(new string[] { "finicity" }, AlphaNumeric(20), true)));
			res.Add(new SecretRegex("finicity-api-token", SemiGenericRegex(new string[] { "finicity" }, Hex(32), true)));
			res.Add(new SecretRegex("finnhub-access-token", SemiGenericRegex(new string[] { "finnhub" }, AlphaNumeric(20), true)));
			res.Add(new SecretRegex("flickr-access-token", SemiGenericRegex(new string[] { "flickr" }, AlphaNumeric(32), true)));
			res.Add(new SecretRegex("flutterwave-public-key", MustCompile(@"FLWPUBK_TEST-(?i)[a-h0-9]{32}-X")));
			res.Add(new SecretRegex("frameio-api-token", MustCompile(@"fio-u-(?i)[a-z0-9\-_=]{64}")));
			res.Add(new SecretRegex("freshbooks-access-token", SemiGenericRegex(new string[] { "freshbooks" }, AlphaNumeric(64), true)));
			res.Add(new SecretRegex("gcp-api-key", UniqueTokenRegex(@"AIza[0-9A-Za-z\-_]{35}", true)));
			res.Add(new SecretRegex("github-pat", MustCompile(@"ghp_[0-9a-zA-Z]{36}")));
			res.Add(new SecretRegex("github-fine-grained-pat", MustCompile(@"github_pat_[0-9a-zA-Z_]{82}")));
			res.Add(new SecretRegex("github-oauth", MustCompile(@"gho_[0-9a-zA-Z]{36}")));
			res.Add(new SecretRegex("github-app-token", MustCompile(@"(ghu|ghs)_[0-9a-zA-Z]{36}")));
			res.Add(new SecretRegex("gitlab-pat", MustCompile(@"glpat-[0-9a-zA-Z\-\_]{20}")));
			res.Add(new SecretRegex("gitlab-ptt", MustCompile(@"glptt-[0-9a-f]{40}")));
			res.Add(new SecretRegex("gitlab-rrt", MustCompile(@"GR1348941[0-9a-zA-Z\-\_]{20}")));
			res.Add(new SecretRegex("gitter-access-token", SemiGenericRegex(new string[] { "gitter" }, AlphaNumericExtendedShort(40), true)));
			res.Add(new SecretRegex("gocardless-api-token", SemiGenericRegex(new string[] { "gocardless" }, @"live_[a-z0-9\-_=]{40}", true)));
			res.Add(new SecretRegex("grafana-api-key", UniqueTokenRegex(@"eyJrIjoi[A-Za-z0-9]{70,400}={0,2}", true)));
			res.Add(new SecretRegex("grafana-cloud-api-token", UniqueTokenRegex(@"glc_[A-Za-z0-9+/]{32,400}={0,2}", true)));
			res.Add(new SecretRegex("grafana-service-account-token", UniqueTokenRegex(@"glsa_[A-Za-z0-9]{32}_[A-Fa-f0-9]{8}", true)));
			res.Add(new SecretRegex("hashicorp-tf-api-token", MustCompile(@"(?i)[a-z0-9]{14}\.atlasv1\.[a-z0-9\-_=]{60,70}")));
			res.Add(new SecretRegex("heroku-api-key", SemiGenericRegex(new string[] { "heroku" }, Hex8_4_4_4_12(), true)));
			res.Add(new SecretRegex("hubspot-api-key", SemiGenericRegex(new string[] { "hubspot" }, @"[0-9A-F]{8}-[0-9A-F]{4}-[0-9A-F]{4}-[0-9A-F]{4}-[0-9A-F]{12}", true)));
			res.Add(new SecretRegex("intercom-api-key", SemiGenericRegex(new string[] { "intercom" }, AlphaNumericExtended(60), true)));
			res.Add(new SecretRegex("jfrog-api-key", SemiGenericRegex(new string[] { "jfrog", "artifactory", "bintray", "xray" }, AlphaNumeric(73), true)));
			res.Add(new SecretRegex("jwt", UniqueTokenRegex(@"ey[a-zA-Z0-9]{17,}\.ey[a-zA-Z0-9\/\_-]{17,}\.(?:[a-zA-Z0-9\/\_-]{10,}={0,2})?", false)));
			res.Add(new SecretRegex("jwt-base64", MustCompile(@"\bZXlK(?:(aGJHY2lPaU)|(aGNIVWlPaU)|(aGNIWWlPaU)|(aGRXUWlPaU)|(aU5qUWlP)|(amNtbDBJanBi)|(amRIa2lPaU)|(bGNHc2lPbn)|(bGJtTWlPaU)|(cWEzVWlPaU)|(cWQyc2lPb)|(cGMzTWlPaU)|(cGRpSTZJ)|(cmFXUWlP)|(clpYbGZiM0J6SWpwY)|(cmRIa2lPaUp)|(dWIyNWpaU0k2)|(d01tTWlP)|(d01uTWlPaU)|(d2NIUWlPaU)|(emRXSWlPaU)|(emRuUWlP)|(MFlXY2lPaU)|(MGVYQWlPaUp)|(MWNtd2l)|(MWMyVWlPaUp)|(MlpYSWlPaU)|(MlpYSnphVzl1SWpv)|(NElqb2)|(NE5XTWlP)|(NE5YUWlPaU)|(NE5YUWpVekkxTmlJNkl)|(NE5YVWlPaU)|(NmFYQWlPaU))[a-zA-Z0-9\/\_+\-\r\n]{40,}={0,2}")));
			res.Add(new SecretRegex("kraken-access-token", SemiGenericRegex(new string[] { "kraken" }, AlphaNumericExtendedLong("80,90"), true)));
			res.Add(new SecretRegex("kucoin-access-token", SemiGenericRegex(new string[] { "kucoin" }, Hex(24), true)));
			res.Add(new SecretRegex("launchdarkly-access-token", SemiGenericRegex(new string[] { "launchdarkly" }, AlphaNumericExtended(40), true)));
			res.Add(new SecretRegex("linear-api-key", MustCompile(@"lin_api_(?i)[a-z0-9]{40}")));
			res.Add(new SecretRegex("linkedin-client-secret", SemiGenericRegex(new string[] { "linkedin", "linked-in" }, AlphaNumeric(16), true)));
			res.Add(new SecretRegex("lob-pub-api-key", SemiGenericRegex(new string[] { "lob" }, @"(test|live)_pub_[a-f0-9]{31}", true)));
			res.Add(new SecretRegex("mailchimp-api-key", SemiGenericRegex(new string[] { "mailchimp" }, @"[a-f0-9]{32}-us20", true)));
			res.Add(new SecretRegex("mailgun-private-api-token", SemiGenericRegex(new string[] { "mailgun" }, @"key-[a-f0-9]{32}", true)));
			res.Add(new SecretRegex("mailgun-pub-key", SemiGenericRegex(new string[] { "mailgun" }, @"pubkey-[a-f0-9]{32}", true)));
			res.Add(new SecretRegex("mailgun-signing-key", SemiGenericRegex(new string[] { "mailgun" }, @"[a-h0-9]{32}-[a-h0-9]{8}-[a-h0-9]{8}", true)));
			res.Add(new SecretRegex("mapbox-api-token", SemiGenericRegex(new string[] { "mapbox" }, @"pk\.[a-z0-9]{60}\.[a-z0-9]{22}", true)));
			res.Add(new SecretRegex("mattermost-access-token", SemiGenericRegex(new string[] { "mattermost" }, AlphaNumeric(26), true)));
			res.Add(new SecretRegex("messagebird-api-token", SemiGenericRegex(new string[] { "messagebird", "message-bird", "message_bird" }, AlphaNumeric(25), true)));
			res.Add(new SecretRegex("netlify-access-token", SemiGenericRegex(new string[] { "netlify" }, AlphaNumericExtended("40,46"), true)));
			res.Add(new SecretRegex("new-relic-user-api-key", SemiGenericRegex(new string[] { "new-relic", "newrelic", "new_relic" }, @"NRAK-[a-z0-9]{27}", true)));
			res.Add(new SecretRegex("new-relic-user-api-id", SemiGenericRegex(new string[] { "new-relic", "newrelic", "new_relic" }, AlphaNumeric(64), true)));
			res.Add(new SecretRegex("new-relic-browser-api-token", SemiGenericRegex(new string[] { "new-relic", "newrelic", "new_relic" }, @"NRJS-[a-f0-9]{19}", true)));
			res.Add(new SecretRegex("npm-access-token", UniqueTokenRegex(@"npm_[a-z0-9]{36}", true)));
			res.Add(new SecretRegex("nytimes-access-token", SemiGenericRegex(new string[] { "nytimes", "new-york-times,", "newyorktimes" }, AlphaNumericExtended(32), true)));
			res.Add(new SecretRegex("okta-access-token", SemiGenericRegex(new string[] { "okta" }, AlphaNumericExtended(42), true)));
			res.Add(new SecretRegex("openai-api-key", UniqueTokenRegex(@"sk-[a-zA-Z0-9]{20}T3BlbkFJ[a-zA-Z0-9]{20}", true)));
			res.Add(new SecretRegex("plaid-client-id", SemiGenericRegex(new string[] { "plaid" }, AlphaNumeric(24), true)));
			res.Add(new SecretRegex("plaid-secret-key", SemiGenericRegex(new string[] { "plaid" }, AlphaNumeric(30), true)));
			res.Add(new SecretRegex("plaid-api-token", SemiGenericRegex(new string[] { "plaid" }, $"access-(?:sandbox|development|production)-{Hex8_4_4_4_12()}", true)));
			res.Add(new SecretRegex("planetscale-password", UniqueTokenRegex(@"pscale_pw_(?i)[a-z0-9=\-_\.]{32,64}", true)));
			res.Add(new SecretRegex("planetscale-api-token", UniqueTokenRegex(@"pscale_tkn_(?i)[a-z0-9=\-_\.]{32,64}", true)));
			res.Add(new SecretRegex("planetscale-oauth-token", UniqueTokenRegex(@"pscale_oauth_(?i)[a-z0-9=\-_\.]{32,64}", true)));
			res.Add(new SecretRegex("postman-api-token", UniqueTokenRegex(@"PMAK-(?i)[a-f0-9]{24}\-[a-f0-9]{34}", true)));
			res.Add(new SecretRegex("prefect-api-token", UniqueTokenRegex(@"pnu_[a-z0-9]{36}", true)));
			res.Add(new SecretRegex("pulumi-api-token", UniqueTokenRegex(@"pul-[a-f0-9]{40}", true)));
			res.Add(new SecretRegex("pypi-upload-token", MustCompile(@"pypi-AgEIcHlwaS5vcmc[A-Za-z0-9\-_]{50,1000}")));
			res.Add(new SecretRegex("rapidapi-access-token", SemiGenericRegex(new string[] { "rapidapi" }, AlphaNumericExtendedShort(50), true)));
			res.Add(new SecretRegex("readme-api-token", UniqueTokenRegex(@"rdme_[a-z0-9]{70}", true)));
			res.Add(new SecretRegex("rubygems-api-token", UniqueTokenRegex(@"rubygems_[a-f0-9]{48}", true)));
			res.Add(new SecretRegex("scalingo-api-token", MustCompile(@"\btk-us-[a-zA-Z0-9-_]{48}\b")));
			res.Add(new SecretRegex("sendbird-access-token", SemiGenericRegex(new string[] { "sendbird" }, Hex(40), true)));
			res.Add(new SecretRegex("sendbird-access-id", SemiGenericRegex(new string[] { "sendbird" }, Hex8_4_4_4_12(), true)));
			res.Add(new SecretRegex("sendgrid-api-token", UniqueTokenRegex(@"SG\.(?i)[a-z0-9=_\-\.]{66}", true)));
			res.Add(new SecretRegex("sendinblue-api-token", UniqueTokenRegex(@"xkeysib-[a-f0-9]{64}\-(?i)[a-z0-9]{16}", true)));
			res.Add(new SecretRegex("sentry-access-token", SemiGenericRegex(new string[] { "sentry" }, Hex(64), true)));
			res.Add(new SecretRegex("shippo-api-token", UniqueTokenRegex(@"shippo_(live|test)_[a-f0-9]{40}", true)));
			res.Add(new SecretRegex("shopify-shared-secret", MustCompile(@"shpss_[a-fA-F0-9]{32}")));
			res.Add(new SecretRegex("shopify-access-token", MustCompile(@"shpat_[a-fA-F0-9]{32}")));
			res.Add(new SecretRegex("shopify-custom-access-token", MustCompile(@"shpca_[a-fA-F0-9]{32}")));
			res.Add(new SecretRegex("shopify-private-app-access-token", MustCompile(@"shppa_[a-fA-F0-9]{32}")));
			res.Add(new SecretRegex("sidekiq-secret", SemiGenericRegex(new string[] { "BUNDLE_ENTERPRISE__CONTRIBSYS__COM", "BUNDLE_GEMS__CONTRIBSYS__COM" }, @"[a-f0-9]{8}:[a-f0-9]{8}", true)));
			res.Add(new SecretRegex("sidekiq-sensitive-url", MustCompile(@"(?i)\b(http(?:s??):\/\/)([a-f0-9]{8}:[a-f0-9]{8})@(?:gems.contribsys.com|enterprise.contribsys.com)(?:[\/|\#|\?|:]|$)")));
			res.Add(new SecretRegex("slack-bot-token", MustCompile(@"(xoxb-[0-9]{10,13}\-[0-9]{10,13}[a-zA-Z0-9-]*)")));
			res.Add(new SecretRegex("slack-user-token", MustCompile(@"(xox[pe](?:-[0-9]{10,13}){3}-[a-zA-Z0-9-]{28,34})")));
			res.Add(new SecretRegex("slack-app-token", MustCompile(@"(?i)(xapp-\d-[A-Z0-9]+-\d+-[a-z0-9]+)")));
			res.Add(new SecretRegex("slack-config-access-token", MustCompile(@"(?i)(xoxe.xox[bp]-\d-[A-Z0-9]{163,166})")));
			res.Add(new SecretRegex("slack-config-refresh-token", MustCompile(@"(?i)(xoxe-\d-[A-Z0-9]{146})")));
			res.Add(new SecretRegex("slack-legacy-bot-token", MustCompile(@"(xoxb-[0-9]{8,14}\-[a-zA-Z0-9]{18,26})")));
			res.Add(new SecretRegex("slack-legacy-workspace-token", MustCompile(@"(xox[ar]-(?:\d-)?[0-9a-zA-Z]{8,48})")));
			res.Add(new SecretRegex("slack-legacy-token", MustCompile(@"(xox[os]-\d+-\d+-\d+-[a-fA-F\d]+)")));
			res.Add(new SecretRegex("slack-webhook-url", MustCompile(@"(https?:\/\/)?hooks.slack.com\/(services|workflows)\/[A-Za-z0-9+\/]{43,46}")));
			res.Add(new SecretRegex("snyk-api-token", SemiGenericRegex(new string[] { "snyk" }, Hex8_4_4_4_12(), true)));
			res.Add(new SecretRegex("square-access-token", UniqueTokenRegex(@"sq0atp-[0-9A-Za-z\-_]{22}", true)));
			res.Add(new SecretRegex("square-secret", UniqueTokenRegex(@"sq0csp-[0-9A-Za-z\-_]{43}", true)));
			res.Add(new SecretRegex("squarespace-access-token", SemiGenericRegex(new string[] { "squarespace" }, Hex8_4_4_4_12(), true)));
			res.Add(new SecretRegex("stripe-access-token", MustCompile(@"(?i)(sk|pk)_(test|live)_[0-9a-z]{10,32}")));
			res.Add(new SecretRegex("sumologic-access-token", SemiGenericRegex(new string[] { "sumo" }, AlphaNumeric(64), true)));
			res.Add(new SecretRegex("microsoft-teams-webhook", MustCompile(@"https:\/\/[a-z0-9]+\.webhook\.office\.com\/webhookb2\/[a-z0-9]{8}-([a-z0-9]{4}-){3}[a-z0-9]{12}@[a-z0-9]{8}-([a-z0-9]{4}-){3}[a-z0-9]{12}\/IncomingWebhook\/[a-z0-9]{32}\/[a-z0-9]{8}-([a-z0-9]{4}-){3}[a-z0-9]{12}")));
			res.Add(new SecretRegex("telegram-bot-api-token", MustCompile(@"(?i)(?:^|[^0-9])([0-9]{5,16}:A[a-zA-Z0-9_\-]{34})(?:$|[^a-zA-Z0-9_\-])")));
			res.Add(new SecretRegex("travisci-access-token", SemiGenericRegex(new string[] { "travis" }, AlphaNumeric(22), true)));
			res.Add(new SecretRegex("trello-access-token", SemiGenericRegex(new string[] { "trello" }, @"[a-zA-Z-0-9]{32}", true)));
			res.Add(new SecretRegex("twilio-api-key", MustCompile(@"SK[0-9a-fA-F]{32}")));
			res.Add(new SecretRegex("twitch-api-token", SemiGenericRegex(new string[] { "twitch" }, AlphaNumeric(30), true)));
			res.Add(new SecretRegex("twitter-api-key", SemiGenericRegex(new string[] { "twitter" }, AlphaNumeric(25), true)));
			res.Add(new SecretRegex("twitter-api-secret", SemiGenericRegex(new string[] { "twitter" }, AlphaNumeric(50), true)));
			res.Add(new SecretRegex("twitter-bearer-token", SemiGenericRegex(new string[] { "twitter" }, "A{22}[a-zA-Z0-9%]{80,100}", true)));
			res.Add(new SecretRegex("twitter-access-token", SemiGenericRegex(new string[] { "twitter" }, "[0-9]{15,25}-[a-zA-Z0-9]{20,40}", true)));
			res.Add(new SecretRegex("twitter-access-secret", SemiGenericRegex(new string[] { "twitter" }, AlphaNumeric(45), true)));
			res.Add(new SecretRegex("typeform-api-token", SemiGenericRegex(new string[] { "typeform" }, @"tfp_[a-z0-9\-_\.=]{59}", true)));
			res.Add(new SecretRegex("vault-service-token", UniqueTokenRegex(@"hvs\.[a-z0-9_-]{90,100}", true)));
			res.Add(new SecretRegex("vault-batch-token", UniqueTokenRegex(@"hvb\.[a-z0-9_-]{138,212}", true)));
			res.Add(new SecretRegex("yandex-aws-access-token", SemiGenericRegex(new string[] { "yandex" }, @"YC[a-zA-Z0-9_\-]{38}", true)));
			res.Add(new SecretRegex("yandex-api-key", SemiGenericRegex(new string[] { "yandex" }, @"AQVN[A-Za-z0-9_\-]{35,38}", true)));
			res.Add(new SecretRegex("yandex-access-token", SemiGenericRegex(new string[] { "yandex" }, @"t1\.[A-Z0-9a-z_-]+[=]{0,2}\.[A-Z0-9a-z_-]{86}[=]{0,2}", true)));
			res.Add(new SecretRegex("zendesk-secret-key", SemiGenericRegex(new string[] { "zendesk" }, AlphaNumeric(40), true)));
			return res;
		}

		public static Regex MustCompile(string secretRegex)
		{
			return new Regex(secretRegex, RegexOptions.Compiled);
		}

		public static Regex UniqueTokenRegex(string secretRegex, bool isCaseInsensitive = false)
		{
			var sb = new StringBuilder();

			if (isCaseInsensitive)
			{
				sb.Append(CaseInsensitive);
			}

			sb.Append(SecretPrefixUnique);
			sb.Append(secretRegex);
			sb.Append(SecretSuffix);

			return new Regex(sb.ToString(), RegexOptions.Compiled);
		}

		public static Regex SemiGenericRegex(string[] identifiers, string secretRegex, bool isCaseInsensitive = false)
		{
			var sb = new StringBuilder();

			// The identifiers should always be case-insensitive.
			// This is inelegant but prevents an extraneous "(?i:)" from being added to the pattern; it could be removed.
			if (isCaseInsensitive)
			{
				sb.Append(CaseInsensitive);
				WriteIdentifiers(sb, identifiers);
			}
			else
			{
				sb.Append(IdentifierCaseInsensitivePrefix);
				WriteIdentifiers(sb, identifiers);
				sb.Append(IdentifierCaseInsensitiveSuffix);
			}

			sb.Append(Operator);
			sb.Append(SecretPrefix);
			sb.Append(secretRegex);
			sb.Append(SecretSuffix);

			return new Regex(sb.ToString(), RegexOptions.Compiled);
		}

		private static void WriteIdentifiers(StringBuilder sb, string[] identifiers)
		{
			sb.Append(IdentifierPrefix);
			sb.Append(string.Join("|", identifiers));
			sb.Append(IdentifierSuffix);
		}

		public static string Numeric(int size)
		{
			return $"[0-9]{{{size}}}";
		}

		public static string Hex(int size)
		{
			return $"[a-f0-9]{{{size}}}";
		}

		public static string AlphaNumeric(int size)
		{
			return $"[a-z0-9]{{{size}}}";
		}

		public static string AlphaNumericExtendedShort(int size)
		{
			return $"[a-z0-9_-]{{{size}}}";
		}

		public static string AlphaNumericExtended<T>(T size)
		{
			return $"[a-z0-9=_\\-]{{{size}}}";
		}

		public static string AlphaNumericExtendedLong<T>(T size)
		{
			return $"[a-z0-9\\/=_\\+\\-]{{{size}}}";
		}

		public static string Hex8_4_4_4_12()
		{
			return "[0-9a-f]{8}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{12}";
		}
	}

}