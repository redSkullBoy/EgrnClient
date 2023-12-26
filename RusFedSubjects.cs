using System.ComponentModel;

namespace EgrnClient;

public enum RusFedSubjects
{
    [Description("Республика Адыгея (Адыгея)")]
    Adygea = 1,

    [Description("Республика Башкортостан")]
    Bashkortostan = 2,

    [Description("Республика Бурятия")]
    Buryatia = 3,

    [Description("Республика Алтай")]
    Altai = 4,

    [Description("Республика Дагестан")]
    Dagestan = 5,

    [Description("Республика Ингушетия")]
    Ingushetia = 6,

    [Description("Кабардино-Балкарская Республика")]
    KabardinoBalkaria = 7,

    [Description("Республика Калмыкия")]
    Kalmykia = 8,

    [Description("Республика Карачаево-Черкесская")]
    KarachayCherkess = 9,

    [Description("Республика Карелия")]
    Karelia = 10,

    [Description("Республика Коми")]
    Komi = 11,

    [Description("Республика Марий Эл")]
    MariEl = 12,

    [Description("Республика Мордовия")]
    Mordovia = 13,

    [Description("Республика Саха (Якутия)")]
    Sakha = 14,

    [Description("Республика Северная Осетия - Алания")]
    NorthOssetiaAlania = 15,

    [Description("Республика Татарстан (Татарстан)")]
    Tatarstan = 16,

    [Description("Республика Тыва")]
    Tuva = 17,

    [Description("Удмуртская Республика")]
    Udmurt = 18,

    [Description("Республика Хакасия")]
    Khakassia = 19,

    [Description("Чеченская Республика")]
    Chechnya = 20,

    [Description("Чувашская Республика - Чувашия")]
    Chuvashia = 21,

    [Description("Алтайский Край")]
    AltaiKrai = 22,

    [Description("Краснодарский Край")]
    KrasnodarKrai = 23,

    [Description("Красноярский Край")]
    KrasnoyarskKrai = 24,

    [Description("Приморский Край")]
    PrimorskyKrai = 25,

    [Description("Ставропольский Край")]
    StavropolKrai = 26,

    [Description("Хабаровский Край")]
    KhabarovskKrai = 27,

    [Description("Амурская Область")]
    AmurRegion = 28,

    [Description("Архангельская Область")]
    ArkhangelskRegion = 29,

    [Description("Астраханская Область")]
    AstrakhanRegion = 30,

    [Description("Белгородская Область")]
    BelgorodRegion = 31,

    [Description("Брянская Область")]
    BryanskRegion = 32,

    [Description("Владимирская Область")]
    VladimirRegion = 33,

    [Description("Волгоградская Область")]
    VolgogradRegion = 34,

    [Description("Вологодская Область")]
    VologdaRegion = 35,

    [Description("Воронежская Область")]
    VoronezhRegion = 36,

    [Description("Ивановская Область")]
    IvanovoRegion = 37,

    [Description("Иркутская Область")]
    IrkutskRegion = 38,

    [Description("Калининградская Область")]
    KaliningradRegion = 39,

    [Description("Калужская Область")]
    KalugaRegion = 40,

    [Description("Камчатский Край")]
    KamchatkaKrai = 41,

    [Description("Кемеровская Область")]
    KemerovoRegion = 42,

    [Description("Кировская Область")]
    KirovRegion = 43,

    [Description("Костромская Область")]
    KostromaRegion = 44,

    [Description("Курганская Область")]
    KurganRegion = 45,

    [Description("Курская Область")]
    KurskRegion = 46,

    [Description("Ленинградская Область")]
    LeningradRegion = 47,

    [Description("Липецкая Область")]
    LipetskRegion = 48,

    [Description("Магаданская Область")]
    MagadanRegion = 49,

    [Description("Московская Область")]
    MoscowRegion = 50,

    [Description("Мурманская Область")]
    MurmanskRegion = 51,

    [Description("Нижегородская Область")]
    NizhnyNovgorodRegion = 52,

    [Description("Новгородская Область")]
    NovgorodRegion = 53,

    [Description("Новосибирская Область")]
    NovosibirskRegion = 54,

    [Description("Омская Область")]
    OmskRegion = 55,

    [Description("Оренбургская Область")]
    OrenburgRegion = 56,

    [Description("Орловская Область")]
    OrelRegion = 57,

    [Description("Пензенская Область")]
    PenzaRegion = 58,

    [Description("Пермский Край")]
    PermKrai = 59,

    [Description("Псковская Область")]
    PskovRegion = 60,

    [Description("Ростовская Область")]
    RostovRegion = 61,

    [Description("Рязанская Область")]
    RyazanRegion = 62,

    [Description("Самарская Область")]
    SamaraRegion = 63,

    [Description("Саратовская Область")]
    SaratovRegion = 64,

    [Description("Сахалинская Область")]
    SakhalinRegion = 65,

    [Description("Свердловская Область")]
    SverdlovskRegion = 66,

    [Description("Смоленская Область")]
    SmolenskRegion = 67,

    [Description("Тамбовская Область")]
    TambovRegion = 68,

    [Description("Тверская Область")]
    TverRegion = 69,

    [Description("Томская Область")]
    TomskRegion = 70,

    [Description("Тульская Область")]
    TulaRegion = 71,

    [Description("Тюменская Область")]
    TyumenRegion = 72,

    [Description("Ульяновская Область")]
    UlyanovskRegion = 73,

    [Description("Челябинская Область")]
    ChelyabinskRegion = 74,

    [Description("Забайкальский Край")]
    ZabaykalskyKrai = 75,

    [Description("Ярославская Область")]
    YaroslavlRegion = 76,

    [Description("Город Москва")]
    MoscowCity = 77,

    [Description("Город Санкт-Петербург")]
    SaintPetersburgCity = 78,

    [Description("Еврейская Автономная область")]
    JewishAutonomousRegion = 79,

    [Description("Ненецкий Автономный округ")]
    NenetsAutonomousRegion = 83,

    [Description("Ханты-Мансийский автономный округ - Югра")]
    KhantyMansiAutonomousRegion = 86,

    [Description("Чукотский автономный округ")]
    ChukotkaAutonomousRegion = 87,

    [Description("Ямало-Ненецкий автономный округ")]
    YamaloNenetsAutonomousRegion = 89,

    [Description("Республика Крым")]
    Crimea = 91,

    [Description("Город Севастополь")]
    SevastopolCity = 92,

    [Description("Город Байконур")]
    BaikonurCity = 99
}