using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace textBot_v0._002
{
    class TextBot
    {
        static List<string> hello = new List<string>(); // Список фраз приветствия
        static List<string> error = new List<string>(); // Фразы непоняток
        static List<string> botBusiness = new List<string>(); // Как дела у бота
        static List<string> goodUserBus = new List<string>(); // Дела пользователя - хорошо
        static List<string> badUserBus = new List<string>(); // Дела - плохло
        static List<string> doStudy = new List<string>(); // Пользователь занимается уроками
        static List<string> rest = new List<string>(); // Пользователь отдыхает
        static List<string> watching = new List<string>(); // Пользователь смотрит
        static List<string> walk = new List<string>(); // Пользователь гуляет
        static List<string> getReady = new List<string>(); // Пользователь готовится
        static List<string> boring = new List<string>(); // Пользователь скучает
        static List<string> thanks = new List<string>(); // Спасибо
        static List<string> sadness = new List<string>(); // Пользователь скучает
        static List<string> missDima = new List<string>(); // Пользователь скучает по Диме
        static List<string> love = new List<string>(); // Пользователь любит Диму
        static List<string> commands = new List<string>(); // Просмотр команд

        /// <summary>
        /// Метод, выполняющий анализ полученного сообщения
        /// </summary>
        /// <param name="letter"> Полученное сообщение </param>
        /// <returns> Возвращает ответное сообщение </returns>
        static public string PhraseAnalysis(string letter)
        {
            Random rnd = new Random();
            bool foundAnswer = false;
            string answer = "Дитрий: ";
            // Если поздоровались с ботом
            if (letter.ToLower().Contains("привет") || letter.ToLower().Contains("здравствуй") || letter.ToLower().Contains("приветики") ||
                letter.ToLower().Contains("хай") || letter.ToLower().Contains("дроу") || letter.ToLower().Contains("приветик"))
            {
                foundAnswer=true; // Отмечаем, что найден хоть один ответ
                int phraseIndex = rnd.Next(0, hello.Count);
                answer += hello[phraseIndex] + "\n"; // То он ответит 1 из фраз приветствия
            }
            // Если поздоровались, написав доброе или что-то такое 
            else if (letter.ToLower().Contains("доброе утро") || letter.ToLower().Contains("добрый день") || letter.ToLower().Contains("добрый вечер") ||
                letter.ToLower().Contains("доброе") || letter.ToLower().Contains("добрый"))
            {
                foundAnswer = true; // Отмечаем, что найден хоть один ответ
                int phraseIndex = rnd.Next(0, hello.Count + 2);
                if (phraseIndex == hello.Count + 1)
                    answer += letter + "\n"; // То ответит либо тем же самым сообщением
                else if (phraseIndex == hello.Count)
                    answer += letter.Split()[0] + "\n"; // Либо первым словом (доброе и тд).
                else
                    answer += hello[phraseIndex] + "\n"; // Либо 1 из фраз приветсвия
            }
            // Если спросили как поживает бот
            if (letter.ToLower().Contains("как жизнь") || letter.ToLower().Contains("как дела") || letter.ToLower().Contains("как ты") ||
                letter.ToLower().Contains("что расскажешь") || letter.ToLower().Contains("чем занимаешься") || letter.ToLower().Contains("что делаешь"))
            {
                foundAnswer = true; // Отмечаем, что найден хоть один ответ
                int phraseIndex = rnd.Next(0, botBusiness.Count);
                answer += botBusiness[phraseIndex] + "\n";
            }
            // Если пользователь сказал, что дела хорошо
            if (letter.ToLower().Contains("всё хорошо") || letter.ToLower().Contains("хорошо") || letter.ToLower().Contains("отлично") ||
                letter.ToLower().Contains("всё потрясающе") || letter.ToLower().Contains("нормально") || letter.ToLower().Contains("нормас") ||
                letter.ToLower().Contains("неплохо") || letter.ToLower().Contains("замечательно") || letter.ToLower().Contains("ничего") || letter.ToLower().Contains("пока не родила"))
            {
                foundAnswer = true; // Отмечаем, что найден хоть один ответ
                int phraseIndex = rnd.Next(0, goodUserBus.Count);
                answer += goodUserBus[phraseIndex] + "\n";
            }
            // Если пользователь сказал, что дела плохо
            if (!letter.ToLower().Contains("неплохо") && (letter.ToLower().Contains("мне плохо") || letter.ToLower().Contains("ужасно") || letter.ToLower().Contains("плохо") ||
                letter.ToLower().Contains("говно") || letter.ToLower().Contains("дерьмо") || letter.ToLower().Contains("зараза") || letter.ToLower().Contains("ужасно") ||
                letter.ToLower().Contains("ужас") || letter.ToLower().Contains("капец") || letter.ToLower().Contains("пипец")))
            {
                foundAnswer = true; // Отмечаем, что найден хоть один ответ
                int phraseIndex = rnd.Next(0, badUserBus.Count);
                answer += badUserBus[phraseIndex] + "\n";
            }
            // Ответ, что занимается уроками
            if (letter.ToLower().Contains("уроки") || letter.ToLower().Contains("уроками") || letter.ToLower().Contains("учусь") ||
                letter.ToLower().Contains("учёбой") || letter.ToLower().Contains("учёба") || letter.ToLower().Contains("дз")
                || letter.ToLower().Contains("домашк"))
            {
                foundAnswer = true; // Отмечаем, что найден хоть один ответ
                int phraseIndex = rnd.Next(0, doStudy.Count);
                answer += doStudy[phraseIndex] + "\n";
            }
            // Ответ, что отдыхает
            if (letter.ToLower().Contains("отдыхаю") || letter.ToLower().Contains("лежу") || letter.ToLower().Contains("отдохнуть") ||
                letter.ToLower().Contains("расслабляюсь") || letter.ToLower().Contains("чилю") || letter.ToLower().Contains("отдых"))
            {
                foundAnswer = true; // Отмечаем, что найден хоть один ответ
                int phraseIndex = rnd.Next(0, rest.Count);
                answer += rest[phraseIndex] + "\n";
            }
            // Ответ, что смотрит 
            if (letter.ToLower().Contains("смотрю сериал") || letter.ToLower().Contains("смотрю фильм") || letter.ToLower().Contains("смотрю тв") ||
                letter.ToLower().Contains("смотрю телек") || letter.ToLower().Contains("смотрю телевизор") || letter.ToLower().Contains("сериал") || letter.ToLower().Contains("фильм")
                || letter.ToLower().Contains("кино") || letter.ToLower().Contains("телек") || letter.ToLower().Contains("телевизор"))
            {
                foundAnswer = true; // Отмечаем, что найден хоть один ответ
                int phraseIndex = rnd.Next(0, watching.Count);
                answer += watching[phraseIndex] + "\n";
            }
            // Ответ, что гуляет 
            if (letter.ToLower().Contains("иду гулять") || letter.ToLower().Contains("собираюсь гулять") || letter.ToLower().Contains("иду на улицу") ||
                letter.ToLower().Contains("собираюсь на прогулку") || letter.ToLower().Contains("прогулк") || letter.ToLower().Contains("гулять") || letter.ToLower().Contains("на улицу"))
            {
                foundAnswer = true; // Отмечаем, что найден хоть один ответ
                int phraseIndex = rnd.Next(0, walk.Count);
                answer += walk[phraseIndex] + "\n";
            }
            // Ответ, что готовится 
            if (letter.ToLower().Contains("готовлюсь к экзаменам") || letter.ToLower().Contains("готовлюсь") || letter.ToLower().Contains("повторяю") ||
                letter.ToLower().Contains("готовлюсь к зачётам") || letter.ToLower().Contains("экзамен") || letter.ToLower().Contains("зачёт") || letter.ToLower().Contains("сдач"))
            {
                foundAnswer = true; // Отмечаем, что найден хоть один ответ
                int phraseIndex = rnd.Next(0, getReady.Count);
                answer += getReady[phraseIndex] + "\n";
            }
            // Ответ, что не знает, чем заняться (скучает) 
            if (letter.ToLower().Contains("не знаю, чем заняться") || letter.ToLower().Contains("скучно") || letter.ToLower().Contains("что поделать") ||
                letter.ToLower().Contains("нечего делать") || letter.ToLower().Contains("чем себя занять") || letter.ToLower().Contains("скучаю") || letter.ToLower().Contains("чем заняться"))
            {
                foundAnswer = true; // Отмечаем, что найден хоть один ответ
                int phraseIndex = rnd.Next(0, boring.Count);
                answer += boring[phraseIndex] + "\n";
            }
            // Ответ - спасибо 
            if (letter.ToLower().Contains("благодарю") || letter.ToLower().Contains("спасибо") || letter.ToLower().Contains("спасиб"))
            {
                foundAnswer = true; // Отмечаем, что найден хоть один ответ
                int phraseIndex = rnd.Next(0, thanks.Count);
                answer += thanks[phraseIndex] + "\n";
            }
            // Грустит
            if (letter.ToLower().Contains("страдаю") || letter.ToLower().Contains("грущу") || letter.ToLower().Contains("все обижают меня") || letter.ToLower().Contains("страдания")
                || letter.ToLower().Contains("грусть") || letter.ToLower().Contains("печаль") || letter.ToLower().Contains("тоска"))
            {
                foundAnswer = true; // Отмечаем, что найден хоть один ответ
                int phraseIndex = rnd.Next(0, sadness.Count);
                answer += sadness[phraseIndex] + "\n";
            }
            // Скучает по Диме
            if (letter.ToLower().Contains("скучаю по диме") || letter.ToLower().Contains("скучаю по тебе") || letter.ToLower().Contains("не хватает димы") || letter.ToLower().Contains("плохо без димы")
                || letter.ToLower().Contains("не хватает тебя") || letter.ToLower().Contains("плохо без тебя") || letter.ToLower().Contains("жду встречи с тобой") 
                || letter.ToLower().Contains("жду встречи с димой"))
            {
                foundAnswer = true; // Отмечаем, что найден хоть один ответ
                int phraseIndex = rnd.Next(0, missDima.Count);
                answer += missDima[phraseIndex] + "\n";
            }
            // Любит Диму
            if (letter.ToLower().Contains("люблю диму") || letter.ToLower().Contains("люблю тебя") || letter.ToLower().Contains("дима лучший") || letter.ToLower().Contains("ты лучший")
                || letter.ToLower().Contains("люблю") || letter.ToLower().Contains("обожаю диму") || letter.ToLower().Contains("обожаю тебя")
                || letter.ToLower().Contains("обожаю") || letter.ToLower().Contains("целую диму") || letter.ToLower().Contains("целую тебя") || letter.ToLower().Contains("целую"))
            {
                foundAnswer = true; // Отмечаем, что найден хоть один ответ
                int phraseIndex = rnd.Next(0, love.Count);
                answer += love[phraseIndex] + "\n";
            }
            if (letter.ToLower().Contains("что ты можешь") || letter.ToLower().Contains("что ты умеешь") || letter.ToLower().Contains("команды") || letter.ToLower().Contains("возможности"))
            {
                foundAnswer = true; // Отмечаем, что найден хоть один ответ
                answer += commands[0] + "\n";
            }
            // Если фраза не подошла ни под одно условие, то скажем, что не поняли фразы
            if (foundAnswer == false)
            {
                int phraseIndex = rnd.Next(0, error.Count);
                answer += error[phraseIndex] + "\n";
            }
            return answer;
        }

        /// <summary>
        /// Метод, вызывающий начальное приветствие бота и подгружающий фразы
        /// </summary>
        /// <returns> Возвращает строку ответа </returns>
        static public string FirstPhrase()
        {
            // Подгружаем в список фразы бота по данной теме разговора
            using (StreamReader sr = new StreamReader("data\\hello.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string str = sr.ReadLine();
                    if(str!="")
                        hello.Add(str);
                }
            }
            // Аналогично далее
            using (StreamReader sr = new StreamReader("data\\error.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string str = sr.ReadLine();
                    if (str != "")
                        error.Add(str);
                }
            }
            using (StreamReader sr = new StreamReader("data\\botBusiness.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string str = sr.ReadLine();
                    if (str != "")
                        botBusiness.Add(str);
                }
            }
            using (StreamReader sr = new StreamReader("data\\goodUserBus.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string str = sr.ReadLine();
                    if (str != "")
                        goodUserBus.Add(str);
                }
            }
            using (StreamReader sr = new StreamReader("data\\badUserBus.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string str = sr.ReadLine();
                    if (str != "")
                        badUserBus.Add(str);
                }
            }
            using (StreamReader sr = new StreamReader("data\\doStudy.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string str = sr.ReadLine();
                    if (str != "")
                        doStudy.Add(str);
                }
            }
            using (StreamReader sr = new StreamReader("data\\rest.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string str = sr.ReadLine();
                    if (str != "")
                        rest.Add(str);
                }
            }
            using (StreamReader sr = new StreamReader("data\\watching.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string str = sr.ReadLine();
                    if (str != "")
                        watching.Add(str);
                }
            }
            using (StreamReader sr = new StreamReader("data\\walk.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string str = sr.ReadLine();
                    if (str != "")
                        walk.Add(str);
                }
            }
            using (StreamReader sr = new StreamReader("data\\getReady.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string str = sr.ReadLine();
                    if (str != "")
                        getReady.Add(str);
                }
            }
            using (StreamReader sr = new StreamReader("data\\boring.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string str = sr.ReadLine();
                    if (str != "")
                        boring.Add(str);
                }
            }
            using (StreamReader sr = new StreamReader("data\\thanks.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string str = sr.ReadLine();
                    if (str != "")
                        thanks.Add(str);
                }
            }
            using (StreamReader sr = new StreamReader("data\\sadness.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string str = sr.ReadLine();
                    if (str != "")
                        sadness.Add(str);
                }
            }
            using (StreamReader sr = new StreamReader("data\\missDima.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string str = sr.ReadLine();
                    if (str != "")
                        missDima.Add(str);
                }
            }
            using (StreamReader sr = new StreamReader("data\\love.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string str = sr.ReadLine();
                    if (str != "")
                        love.Add(str);
                }
            }
            using (StreamReader sr = new StreamReader("data\\commands.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string str = sr.ReadLine();
                    if (str != "")
                        commands.Add(str);
                }
            }

            string answer = "Дитрий: ";
            answer += "Я разработка Димы - бот Дитрий. Мой создатель вложил в меня частичку своей души. Если тебе скучно, но нет возможности поболтать с твоим Димой" +
                " (например, он на работе или экзамене, ведь остальное время он всегда твой)," +
                " то что же, я постараюсь скрасить минуты ожидания любимого :3\n\n";
            answer += "Дитрий: ";
            answer += "Ты можешь общаться со мной, отправив мне сообщение. Конечно, я не такой потрясающий," +
                " харизматичный и обаятельный рассказчик как твоя радость, но всё же могу тебе немного поднять настроение)." +
                " Если тебе хочется узнать примерный список поддерживаемых команд, то напиши мне 'Команды' или 'А что ты можешь?'. " +
                "А можешь и не писать, хех.\n";
            return answer;
        }

        /// <summary>
        /// Метод, выполняющий проверку системной даты и поздравляющий с праздником, если таковой имеется
        /// </summary>
        /// <param name="date"> Получает на вход объект DateTime </param>
        /// <returns> Возвращает строку поздравления бота </returns>
        static public string PhraseForSpecialDay(DateTime date)
        {
            string answer = "";
            if ((int)date.Day == 1 && (int)date.Month == 1)
            // НГ
            {
                answer = "Дитрий: " + "Сегодня " + date.ToLongDateString() + ". Так что с новым годом тебя, малышка!!!" + "\n";
            }
            else if ((int)date.Day == 14 && (int)date.Month == 2)
            // 14 февраля
            {
                answer = "Дитрий: " + "Сегодня " + date.ToLongDateString() + ". С днём всех влюблённых тебя, принцесса!" + "\n";
            }
            else if ((int)date.Day == 8 && (int)date.Month == 3)
            // 8 март
            {
                answer = "Дитрий: " + "Сегодня " + date.ToLongDateString() + ". С международным женским днём, солнышко любимое!" + "\n";
            }
            else if ((int)date.Day == 28 && (int)date.Month == 4)
            // именины
            {
                answer = "Дитрий: " + "Сегодня " + date.ToLongDateString() + ". С именинами, радость моя!" + "\n";
            }
            else if ((int)date.Day == 14 && (int)date.Month == 5)
            // день отношений
            {
                answer = "Дитрий: " + "Сегодня " + date.ToLongDateString() + " - день начала наших отношений! С раздником, самый дорогой человечек на свете :3 Люблю тебя очень-преочень" + "\n";
            }
            else if ((int)date.Day == 24 && (int)date.Month == 6)
            // День рождения
            {
                answer = "Дитрий: " + "Сегодня " + date.ToLongDateString() + ", а значит, у моей малышки сегодня день рождения! Целую тебя, принцесса <3" + "\n";
            }
            else if ((int)date.Day == 1 && (int)date.Month == 9)
            // день отношений
            {
                answer = "Дитрий: " + "Сегодня " + date.ToLongDateString() + ". Так что с праздником тебя, моя самая лучшая учительница!" + "\n";
            }
            return answer;
        }
    }
}
