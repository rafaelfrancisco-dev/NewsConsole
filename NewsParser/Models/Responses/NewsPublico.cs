using System.Text.Json.Serialization;

namespace NewsParser.Models.Responses
{
    using System;

    public partial class Conteudo
    {
        [JsonPropertyName("id")] public long Id { get; set; }

        [JsonPropertyName("fonte")] public string Fonte { get; set; }

        [JsonPropertyName("dadoId")] public string DadoId { get; set; }

        [JsonPropertyName("conteudoHTML")] public bool ConteudoHtml { get; set; }

        [JsonPropertyName("html")] public string Html { get; set; }

        [JsonPropertyName("conteudo")] public NewsPublico ConteudoConteudo { get; set; }
    }

    public partial class Elemento
    {
        [JsonPropertyName("id")] public long Id { get; set; }

        [JsonPropertyName("nome")] public object Nome { get; set; }

        [JsonPropertyName("titulo")] public object Titulo { get; set; }

        [JsonPropertyName("numColuna")] public long NumColuna { get; set; }

        [JsonPropertyName("coluna")] public long Coluna { get; set; }

        [JsonPropertyName("ordem")] public long Ordem { get; set; }

        [JsonPropertyName("imageUrl")] public object ImageUrl { get; set; }

        [JsonPropertyName("url")] public object Url { get; set; }

        [JsonPropertyName("isAutomatica")] public bool IsAutomatica { get; set; }

        [JsonPropertyName("isPorContexto")] public bool IsPorContexto { get; set; }

        [JsonPropertyName("cacheValue")] public long CacheValue { get; set; }

        [JsonPropertyName("sempreVisivel")] public bool SempreVisivel { get; set; }

        [JsonPropertyName("ignoraContexto")] public bool IgnoraContexto { get; set; }

        [JsonPropertyName("mostraFilete")] public bool MostraFilete { get; set; }

        [JsonPropertyName("editNoLugar")] public bool EditNoLugar { get; set; }

        [JsonPropertyName("carrgeViaAjax")] public bool CarrgeViaAjax { get; set; }

        [JsonPropertyName("estilo")] public Estilo? Estilo { get; set; }

        [JsonPropertyName("tipoCaixa")] public TipoCaixa TipoCaixa { get; set; }

        [JsonPropertyName("conteudos")] public Conteudo[] Conteudos { get; set; }

        [JsonPropertyName("isToIgnorePageContext")]
        public bool IsToIgnorePageContext { get; set; }

        [JsonPropertyName("descricao")] public object Descricao { get; set; }
    }

    public partial class NewsPublico
    {
        [JsonPropertyName("id")] public long Id { get; set; }

        [JsonPropertyName("titulo")] public string Titulo { get; set; }

        [JsonPropertyName("tituloNoticia")] public string TituloNoticia { get; set; }

        [JsonPropertyName("tituloOriginal")] public object TituloOriginal { get; set; }

        [JsonPropertyName("descricao")] public string Descricao { get; set; }

        [JsonPropertyName("texto")] public string Texto { get; set; }

        [JsonPropertyName("url")] public string Url { get; set; }

        [JsonPropertyName("multimediaPrincipal")] public Uri MultimediaPrincipal { get; set; }

        [JsonPropertyName("multimediaPrincipalLegenda")]
        public string MultimediaPrincipalLegenda { get; set; }

        [JsonPropertyName("hasLive")] public bool HasLive { get; set; }

        [JsonPropertyName("pontuacao")] public long? Pontuacao { get; set; }

        [JsonPropertyName("numeroComentarios")] public long NumeroComentarios { get; set; }

        [JsonPropertyName("lead")] public object Lead { get; set; }

        [JsonPropertyName("shortUrl")] public object ShortUrl { get; set; }

        [JsonPropertyName("titulo_Mobile")] public object TituloMobile { get; set; }

        [JsonPropertyName("subtitulo")] public string Subtitulo { get; set; }

        [JsonPropertyName("rubricTag")] public Tag RubricTag { get; set; }

        [JsonPropertyName("rubrica")] public string Rubrica { get; set; }

        [JsonPropertyName("rubricUrl")] public string RubricUrl { get; set; }

        [JsonPropertyName("tipo")] public NewsPublicoTipo? Tipo { get; set; }

        [JsonPropertyName("emActualizacao")] public bool EmActualizacao { get; set; }

        [JsonPropertyName("fechaComentarios")] public bool FechaComentarios { get; set; }

        [JsonPropertyName("emDirecto")] public bool EmDirecto { get; set; }

        [JsonPropertyName("facebook")] public long Facebook { get; set; }

        [JsonPropertyName("twitter")] public long Twitter { get; set; }

        [JsonPropertyName("google")] public long Google { get; set; }

        [JsonPropertyName("fonteMultimediaPrincipal")]
        public FonteMultimediaPrincipal? FonteMultimediaPrincipal { get; set; }

        [JsonPropertyName("palavraChave")] public object PalavraChave { get; set; }

        [JsonPropertyName("itemId")] public string ItemId { get; set; }

        [JsonPropertyName("tokenTipo")] public object TokenTipo { get; set; }

        [JsonPropertyName("numPartilhas")] public long NumPartilhas { get; set; }

        [JsonPropertyName("numComentarios")] public long NumComentarios { get; set; }

        [JsonPropertyName("html")] public object Html { get; set; }

        [JsonPropertyName("tipoLayout")] public TipoLayout? TipoLayout { get; set; }

        [JsonPropertyName("caixaId")] public long? CaixaId { get; set; }

        [JsonPropertyName("isOpinion")] public bool IsOpinion { get; set; }

        [JsonPropertyName("fullUrl")] public string FullUrl { get; set; }

        [JsonPropertyName("prioridade")] public object Prioridade { get; set; }

        [JsonPropertyName("isPreview")] public bool IsPreview { get; set; }

        [JsonPropertyName("escondeImagem")] public bool EscondeImagem { get; set; }

        [JsonPropertyName("aoMinuto")] public bool AoMinuto { get; set; }

        [JsonPropertyName("isFeature")] public bool IsFeature { get; set; }

        [JsonPropertyName("slug")] public string Slug { get; set; }

        [JsonPropertyName("cleanTitle")] public string CleanTitle { get; set; }

        [JsonPropertyName("isHtml")] public bool IsHtml { get; set; }

        [JsonPropertyName("shareUrl")] public string ShareUrl { get; set; }

        [JsonPropertyName("isImagePortait")] public bool IsImagePortait { get; set; }

        [JsonPropertyName("cardInfo")] public CardInfo CardInfo { get; set; }

        [JsonPropertyName("brand")] public object Brand { get; set; }

        [JsonPropertyName("caixaConteudo")] public object CaixaConteudo { get; set; }

        [JsonPropertyName("dataActualizacao")] public DateTimeOffset? DataActualizacao { get; set; }

        [JsonPropertyName("data")] public DateTimeOffset Data { get; set; }

        [JsonPropertyName("autores")] public Autore[] Autores { get; set; }

        [JsonPropertyName("tags")] public Tag[] Tags { get; set; }

        [JsonPropertyName("imagens")] public Image[] Imagens { get; set; }

        [JsonPropertyName("criticas")] public object[] Criticas { get; set; }

        [JsonPropertyName("videos")] public object[] Videos { get; set; }

        [JsonPropertyName("fotogalerias")] public object[] Fotogalerias { get; set; }

        [JsonPropertyName("ficheiros")] public object[] Ficheiros { get; set; }

        [JsonPropertyName("links")] public object[] Links { get; set; }

        [JsonPropertyName("infografias")] public object[] Infografias { get; set; }

        [JsonPropertyName("elementos")] public Elemento[] Elementos { get; set; }

        [JsonPropertyName("fichaTecnica")] public object[] FichaTecnica { get; set; }

        [JsonPropertyName("audios")] public object[] Audios { get; set; }

        [JsonPropertyName("charCount")] public long CharCount { get; set; }

        [JsonPropertyName("iconography")] public string Iconography { get; set; }

        [JsonPropertyName("isSponsorContent")] public bool IsSponsorContent { get; set; }

        [JsonPropertyName("isClubeP")] public bool IsClubeP { get; set; }

        [JsonPropertyName("isItemOpinion")] public bool IsItemOpinion { get; set; }

        [JsonPropertyName("isInlineMedia")] public bool IsInlineMedia { get; set; }

        [JsonPropertyName("hasManualSubtitle")] public bool HasManualSubtitle { get; set; }

        [JsonPropertyName("isMultipleRubric")] public bool IsMultipleRubric { get; set; }

        [JsonPropertyName("socialTitle")] public string SocialTitle { get; set; }

        [JsonPropertyName("isLongForm")] public bool IsLongForm { get; set; }

        [JsonPropertyName("isClosed")] public bool IsClosed { get; set; }

        [JsonPropertyName("isExclusive")] public bool IsExclusive { get; set; }

        [JsonPropertyName("satelliteName")] public SatelliteName SatelliteName { get; set; }

        [JsonPropertyName("userLibraryStatus")] public object UserLibraryStatus { get; set; }

        [JsonPropertyName("maxParagraph")] public long MaxParagraph { get; set; }

        [JsonPropertyName("isHeadline")] public bool IsHeadline { get; set; }

        [JsonPropertyName("wordCount")] public long WordCount { get; set; }

        [JsonPropertyName("extra4")] public object Extra4 { get; set; }

        [JsonPropertyName("partners")] public object Partners { get; set; }

        [JsonPropertyName("props")] public object Props { get; set; }
    }

    public partial class TipoCaixa
    {
        [JsonPropertyName("id")] public long Id { get; set; }

        [JsonPropertyName("nome")] public object Nome { get; set; }

        [JsonPropertyName("token")] public Token Token { get; set; }

        [JsonPropertyName("isCaixaNoticia")] public bool IsCaixaNoticia { get; set; }

        [JsonPropertyName("isVariosConteudos")] public bool IsVariosConteudos { get; set; }

        [JsonPropertyName("conteudoMaximo")] public object ConteudoMaximo { get; set; }

        [JsonPropertyName("carregaSempreViaAjax")] public bool CarregaSempreViaAjax { get; set; }

        [JsonPropertyName("conteudoAleatorio")] public bool ConteudoAleatorio { get; set; }

        [JsonPropertyName("directorio")] public Directorio? Directorio { get; set; }

        [JsonPropertyName("dependeDoConteudo")] public bool DependeDoConteudo { get; set; }

        [JsonPropertyName("exportavel")] public bool Exportavel { get; set; }

        [JsonPropertyName("numMaxConteudo")] public object NumMaxConteudo { get; set; }

        [JsonPropertyName("fontes")] public object[] Fontes { get; set; }
    }

    public partial class Autore
    {
        [JsonPropertyName("id")] public long Id { get; set; }

        [JsonPropertyName("nome")] public string Nome { get; set; }

        [JsonPropertyName("descricao")] public string Descricao { get; set; }

        [JsonPropertyName("email")] public string Email { get; set; }

        [JsonPropertyName("facebook")] public object Facebook { get; set; }

        [JsonPropertyName("googlePlus")] public object GooglePlus { get; set; }

        [JsonPropertyName("twitter")] public object Twitter { get; set; }

        [JsonPropertyName("site")] public object Site { get; set; }

        [JsonPropertyName("url")] public object Url { get; set; }

        [JsonPropertyName("localizacao")] public string Localizacao { get; set; }

        [JsonPropertyName("profissaoActual")] public Profissao? ProfissaoActual { get; set; }

        [JsonPropertyName("profissaoNaAltura")] public Profissao? ProfissaoNaAltura { get; set; }

        [JsonPropertyName("slug")] public string Slug { get; set; }

        [JsonPropertyName("imagem")] public Image Imagem { get; set; }

        [JsonPropertyName("hasImage")] public bool HasImage { get; set; }

        [JsonPropertyName("isExternal")] public bool IsExternal { get; set; }

        [JsonPropertyName("encodedEmail")] public string EncodedEmail { get; set; }

        [JsonPropertyName("contribuicao")] public string Contribuicao { get; set; }

        [JsonPropertyName("tipo")] public AutoreTipo? Tipo { get; set; }
    }

    public partial class Image
    {
        [JsonPropertyName("w")] public long? W { get; set; }

        [JsonPropertyName("h")] public long? H { get; set; }

        [JsonPropertyName("largura")] public long? Largura { get; set; }

        [JsonPropertyName("altura")] public long? Altura { get; set; }

        [JsonPropertyName("nome")] public string Nome { get; set; }

        [JsonPropertyName("legenda")] public string Legenda { get; set; }

        [JsonPropertyName("autor")] public string Autor { get; set; }

        [JsonPropertyName("tipo")] public ImagenTipo Tipo { get; set; }

        [JsonPropertyName("url")] public Uri Url { get; set; }

        [JsonPropertyName("is_vertical")] public bool IsVertical { get; set; }

        [JsonPropertyName("tags")] public string Tags { get; set; }

        [JsonPropertyName("translations")] public object Translations { get; set; }
    }

    public partial class CardInfo
    {
        [JsonPropertyName("css")] public Css[] Css { get; set; }

        [JsonPropertyName("showMedia")] public bool ShowMedia { get; set; }

        [JsonPropertyName("maxLinks")] public long MaxLinks { get; set; }

        [JsonPropertyName("isHeadlineBlock")] public bool IsHeadlineBlock { get; set; }

        [JsonPropertyName("showLead")] public bool ShowLead { get; set; }

        [JsonPropertyName("mediaCss")] public string MediaCss { get; set; }
    }

    public partial class Tag
    {
        [JsonPropertyName("id")] public long Id { get; set; }

        [JsonPropertyName("nome")] public string Nome { get; set; }

        [JsonPropertyName("slug")] public string Slug { get; set; }

        [JsonPropertyName("tagEn")] public TagEn TagEn { get; set; }

        [JsonPropertyName("isPrincipal")] public bool IsPrincipal { get; set; }

        [JsonPropertyName("isVisible")] public bool IsVisible { get; set; }

        [JsonPropertyName("urlRoute")] public string UrlRoute { get; set; }

        [JsonPropertyName("isPrincipalParaArtigo")]
        public bool IsPrincipalParaArtigo { get; set; }

        [JsonPropertyName("isTimeLine")] public bool IsTimeLine { get; set; }

        [JsonPropertyName("forcaConteudoAberto")] public bool ForcaConteudoAberto { get; set; }

        [JsonPropertyName("follow_type")] public object FollowType { get; set; }

        [JsonPropertyName("descricao")] public object Descricao { get; set; }

        [JsonPropertyName("imagem")] public object Imagem { get; set; }

        [JsonPropertyName("html")] public object Html { get; set; }

        [JsonPropertyName("isForForuns")] public bool IsForForuns { get; set; }

        [JsonPropertyName("isUsedInForuns")] public bool IsUsedInForuns { get; set; }
    }

    public enum Estilo
    {
        StoryCalloutInline
    };

    public enum Directorio
    {
        Empty,
        Highlights
    };

    public enum Token
    {
        ArtigoTexto,
        Imagem780_520,
        NoticiaHtml
    };

    public enum ImagenTipo
    {
        Jpg,
        Png
    };

    public enum Profissao
    {
        Empty,
        Jornalista
    };

    public enum AutoreTipo
    {
        Agencia,
        Externo,
        Interno
    };

    public enum Css
    {
        CardF,
        ToneNews
    };

    public enum FonteMultimediaPrincipal
    {
        Imagens
    };

    public enum TagEn
    {
        Economy,
        Empty
    };

    public enum SatelliteName
    {
        Empty,
        Ímpar,
        Ípsilon
    };

    public enum NewsPublicoTipo
    {
        Noticia
    };

    public enum TipoLayout
    {
        LongformNormal,
        MultimediaNormal
    };
}