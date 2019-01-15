using CookIt.Models.Entities;
using CookIt.Repository;
using SQLite;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CookIt.Services
{
    public class DatabaseInitiateService
    {
        private DatabaseRepository _databaseRepository;

        public DatabaseInitiateService()
        {
            _databaseRepository = new DatabaseRepository();
        }

        public void SetDatabase()
        {
            if (_databaseRepository.CheckIfDatabaseIsEmpty())
            {
                List<Recipe> recipes = GetRecipeList();
                recipes.ForEach(recipe => _databaseRepository.Insert(recipe));
            }            
        }

        private List<Recipe> GetRecipeList()
        {
            return new List<Recipe>()
            {
                GetRecipe1PL(),
                GetRecipe1EN(),

                GetRecipe2PL(),
                GetRecipe2EN(),

                GetRecipe3PL(),
                GetRecipe3EN(),

                GetRecipe4PL(),
                GetRecipe4EN(),

                GetRecipe5PL(),
                GetRecipe5EN()
            };
        }

        #region recipes
        private Recipe GetRecipe1PL()
        {
            Recipe recipe = GetRecipe("pl", "Makaron z tuńczykiem i oliwkami", 2, "25 minut", "foto_1.jpg");
            recipe.Ingredients = GetIngredients1PL(recipe);
            recipe.Steps = GetSteps1PL(recipe);

            return recipe;
        }

        private List<Ingredient> GetIngredients1PL(Recipe recipe)
        {
            return new List<Ingredient>()
            {
                GetIngredient(recipe, "130 gram makaronu", "Pasta"),
                GetIngredient(recipe, "1 łyżka oliwy", "OliveOil"),
                GetIngredient(recipe, "3 ząbki czosnku", "Garlic"),
                GetIngredient(recipe, "1 łyżka masła", "Butter"),
                GetIngredient(recipe, "50 gram odcedzonych oliwek", "Olives"),
                GetIngredient(recipe, "100 gram tuńczyka w oleju", "Tuna"),
                GetIngredient(recipe, "2 łyżki posiekanej natki pietruszki", "Parsley"),
                GetIngredient(recipe, "Tarty parmezan", "Parmesan")
            };
        }

        private List<Step> GetSteps1PL(Recipe recipe)
        {
            return new List<Step>()
            {
                GetStep(recipe, 1,
                "Makaron ugotować al dente w osolonej wodzie. Na większą patelnię wlać oliwę, dodać pokrojony na cienkie plasterki czosnek i smażyć przez ok. 2 minuty co chwilę mieszając.",
                "120000"),
                GetStep(recipe, 2,
                "Dodać masło oraz pokrojone na plasterki oliwki i smażyć przez ok. 2 minuty. Dodać tuńczyka, wymieszać i jeszcze przez chwilę podsmażać.",
                "120000"),
                GetStep(recipe, 3,
                "Dodać posiekaną natkę pietruszki, wymieszać, doprawić solą oraz świeżo zmielonym pieprzem. Dodać 3 łyżki oliwy z tuńczyka lub oliwy extra virgine."),
                GetStep(recipe, 4,
                "Dodać ugotowany makaron, wymieszać i podgrzać. Wyłożyć na talerze i posypać tartym parmezanem.")
            };
        }



        private Recipe GetRecipe1EN()
        {
            Recipe recipe = GetRecipe("en", "Pasta with tuna and olives", 2, "25 minutes", "foto_1.jpg");
            recipe.Ingredients = GetIngredients1EN(recipe);
            recipe.Steps = GetSteps1EN(recipe);

            return recipe;
        }

        private List<Ingredient> GetIngredients1EN(Recipe recipe)
        {
            return new List<Ingredient>()
            {
                GetIngredient(recipe, "130 gram of pasta", "Pasta"),
                GetIngredient(recipe, "1 tablespoon of oil", "OliveOil"),
                GetIngredient(recipe, "3 cloves of garlic", "Garlic"),
                GetIngredient(recipe, "1 tablespoon of butter", "Butter"),
                GetIngredient(recipe, "50 gram of drained green olives", "Olives"),
                GetIngredient(recipe, "100 gram of tuna in oil", "Tuna"),
                GetIngredient(recipe, "2 tablespoons of chopped parsley", "Parsley"),
                GetIngredient(recipe, "Grated parmesan cheese", "Parmesan")
            };
        }

        private List<Step> GetSteps1EN(Recipe recipe)
        {
            return new List<Step>()
            {
                GetStep(recipe, 1,
                "Cook pasta al dente in salted water. Pour olive oil into a larger pan, add garlic cut into thin slices and fry for approx. 2 minutes, stirring constantly.",
                "120000"),
                GetStep(recipe, 2,
                "Add butter and sliced olives and fry for approx. 2 minutes. Add the tuna, mix and fry for a while.",
                "120000"),
                GetStep(recipe, 3,
                "Add the chopped parsley, mix, season with salt and freshly ground pepper. Add 3 tablespoons of tuna oil or extra virgin olive oil."),
                GetStep(recipe, 4,
                "Add the cooked pasta, mix and heat. Put on plates and sprinkle with grated parmesan cheese.")
            };
        }



        private Recipe GetRecipe2PL()
        {
            Recipe recipe = GetRecipe("pl", "Schab z suszonymi pomidorami", 4, "1h 30 min", "foto_2.jpg");
            recipe.Ingredients = GetIngredients2PL(recipe);
            recipe.Steps = GetSteps2PL(recipe);

            return recipe;
        }

        private List<Ingredient> GetIngredients2PL(Recipe recipe)
        {
            return new List<Ingredient>()
            {
                GetIngredient(recipe, "600 g schabu", "PorkChop"),
                GetIngredient(recipe, "2 łyżki oliwy", "OliveOil"),
                GetIngredient(recipe, "1 łyżeczka oregano", "Oregano"),
                GetIngredient(recipe, "200 ml wody", "Water"),
                GetIngredient(recipe, "100 ml białego wina półwytrawnego", "Wine"),
                GetIngredient(recipe, "2 łyżki sosu sojowego", "SoySauce"),
                GetIngredient(recipe, "ok. 10 kawałków suszonych pomidorów", "DriedTomatoes"),
                GetIngredient(recipe, "1/2 łyżeczki mąki ziemniaczanej", "Flour")
            };
        }

        private List<Step> GetSteps2PL(Recipe recipe)
        {
            return new List<Step>()
            {
                GetStep(recipe, 1,
                "W szerokim garnku rozgrzać oliwę i włożyć plastry schabu. Obsmażyć na dużym ogniu z obu stron do zrumienienia, następnie doprawić solą, zmielonym pieprzem i suszonym oregano."),
                GetStep(recipe, 2,
                "Wlać gorącą wodę oraz wino. Doprawić sosem sojowym, dodać suszone pomidory oraz oliwę. Przykryć i dusić na małym ogniu przez ok. 1 godzinę, lub do miękkości mięsa. Mniej więcej w połowie gotowania poprzekładać plastry mięsa na drugą stronę.",
                "3600000"),
                GetStep(recipe, 3,
                "Na koniec dodać przez sitko mąkę ziemniaczaną, wymieszać i zagotować.")
            };
        }



        private Recipe GetRecipe2EN()
        {
            Recipe recipe = GetRecipe("en", "Pork loin with sun-dried tomatoes", 4, "1h 30 min", "foto_2.jpg");
            recipe.Ingredients = GetIngredients2EN(recipe);
            recipe.Steps = GetSteps2PL(recipe);

            return recipe;
        }

        private List<Ingredient> GetIngredients2EN(Recipe recipe)
        {
            return new List<Ingredient>()
            {
                GetIngredient(recipe, "600 g loin", "PorkChop"),
                GetIngredient(recipe, "2 tablespoons of oil", "OliveOil"),
                GetIngredient(recipe, "1 teaspoon of oregano", "Oregano"),
                GetIngredient(recipe, "200 ml of water", "Water"),
                GetIngredient(recipe, "100 ml of white semi-dry wine", "Wine"),
                GetIngredient(recipe, "2 tablespoons of soy sauce", "SoySauce"),
                GetIngredient(recipe, "about 10 pieces of dried tomatoes", "DriedTomatoes"),
                GetIngredient(recipe, "1/2 teaspoon of potato flour", "Flour")
            };
        }

        private List<Step> GetSteps2EN(Recipe recipe)
        {
            return new List<Step>()
            {
                GetStep(recipe, 1,
                "In a wide pan warm up the oil and put on the slices of pork. Fry on high heat from both sides until brown, then season with salt, ground pepper and dried oregano."),
                GetStep(recipe, 2,
                "Pour hot water and wine. Season with soy sauce, add dried tomatoes and olive oil. Cover and simmer over low heat for about 1 hour, or until the meat is tender. Approximately halfway through the cooking, tweak the slices of meat to the other side.",
                "3600000"),
                GetStep(recipe, 3,
                "Finally add the potato flour through the sieve, mix and bring to a boil.")
            };
        }



        private Recipe GetRecipe3PL()
        {
            Recipe recipe = GetRecipe("pl", "Makaron z łososiem i cukinią", 4, "40 min", "foto_3.jpg");
            recipe.Ingredients = GetIngredients3PL(recipe);
            recipe.Steps = GetSteps3PL(recipe);

            return recipe;
        }

        private List<Ingredient> GetIngredients3PL(Recipe recipe)
        {
            return new List<Ingredient>()
            {
                GetIngredient(recipe, "150 g makaronu", "Pasta"),
                GetIngredient(recipe, "150 g łososia wędzonego", "SmokedSalmon"),
                GetIngredient(recipe, "1/2 cukinii", "Zucchini"),
                GetIngredient(recipe, "8 kawałków suszonych pomidorów", "DriedTomatoes"),
                GetIngredient(recipe, "100 ml śmietanki 30%", "Cream"),
                GetIngredient(recipe, "2 łyżki masła", "Butter")
            };
        }

        private List<Step> GetSteps3PL(Recipe recipe)
        {
            return new List<Step>()
            {
                GetStep(recipe, 1,
                "Makaron ugotować al dente w osolonej wodzie, po ugotowaniu odcedzić."),
                GetStep(recipe, 2,
                "Łososia pokroić w kosteczkę. Cukinię pokroić na plasterki, następnie na paseczki - \"zapałki\". Suszone pomidory zmiksować na pastę."),
                GetStep(recipe, 3,
                "Do garnka po makaronie włożyć masło, łososia oraz cukinię. Doprawić świeżo zmielonym pieprzem i smażyć przez 2 minuty co chwilę mieszając. Na koniec doprawić małą szczyptą soli.",
                "120000"),
                GetStep(recipe, 4,
                "Dodać odcedzony makaron oraz śmietankę, wymieszać i zagotować. Podgrzewać jeszcze przez ok. 2 minuty lub do czasu aż sos zgęstnieje.",
                "120000"),
                GetStep(recipe, 5,
                "Makaron wyłożyć na talerze, dodać zmiksowane suszone pomidory, udekorować bazylią i podawać z cząstką cytryny.")
            };
        }



        private Recipe GetRecipe3EN()
        {
            Recipe recipe = GetRecipe("en", "Pasta with salmon and zucchini", 4, "40 min", "foto_3.jpg");
            recipe.Ingredients = GetIngredients3EN(recipe);
            recipe.Steps = GetSteps3EN(recipe);

            return recipe;
        }

        private List<Ingredient> GetIngredients3EN(Recipe recipe)
        {
            return new List<Ingredient>()
            {
                GetIngredient(recipe, "150 g of pasta", "Pasta"),
                GetIngredient(recipe, "150 g smoked salmon", "SmokedSalmon"),
                GetIngredient(recipe, "1/2 zucchini", "Zucchini"),
                GetIngredient(recipe, "8 pieces of dried tomatoes", "DriedTomatoes"),
                GetIngredient(recipe, "100 ml cream 30%", "Cream"),
                GetIngredient(recipe, "2 tablespoons of butter", "Butter")
            };
        }

        private List<Step> GetSteps3EN(Recipe recipe)
        {
            return new List<Step>()
            {
                GetStep(recipe, 1,
                "Cook pasta al dente in salted water, strain after cooking."),
                GetStep(recipe, 2,
                "Cut the salmon into cubes. Cut zucchini into slices, then into strips - \"matches\". Dried tomatoes are mixed into a paste."),
                GetStep(recipe, 3,
                "Put the butter, salmon and zucchini into the pasta pot. Season with freshly ground pepper and fry for 2 minutes stirring constantly. At the end, season with a small pinch of salt.",
                "120000"),
                GetStep(recipe, 4,
                "Add drained pasta and cream, mix and bring to a boil. Heat for approx. 2 minutes or until the sauce thickens.",
                "120000"),
                GetStep(recipe, 5,
                "Put pasta on plates, add dried tomatoes, decorate with basil and serve with a lemon slice.")
            };
        }



        private Recipe GetRecipe4PL()
        {
            Recipe recipe = GetRecipe("pl", "Ciasteczka z czekoladą", 13, "50 min", "foto_4.jpg");
            recipe.Ingredients = GetIngredients4PL(recipe);
            recipe.Steps = GetSteps4PL(recipe);

            return recipe;
        }

        private List<Ingredient> GetIngredients4PL(Recipe recipe)
        {
            return new List<Ingredient>()
            {
                GetIngredient(recipe, "100 g czekolady deserowej", "Chocolate"),
                GetIngredient(recipe, "100 g masła", "Butter"),
                GetIngredient(recipe, "1/2 szklanki cukru pudru", "PowderedSugar"),
                GetIngredient(recipe, "2 łyżki kakao", "Cocoa"),
                GetIngredient(recipe, "1 jajko", "Eggs"),
                GetIngredient(recipe, "220 g mąki pszennej", "Flour"),
                GetIngredient(recipe, "1/2 łyżeczki sody", "BakingSoda"),
                GetIngredient(recipe, "1/4 łyżeczki proszku do pieczenia", "BakingPowder")
            };
        }

        private List<Step> GetSteps4PL(Recipe recipe)
        {
            return new List<Step>()
            {
                GetStep(recipe, 1,
                "Czekoladę podzielić na kostki. Masło pokroić i ocieplić w temperaturze pokojowej. Piekarnik nagrzać do 180 stopni C."),
                GetStep(recipe, 2,
                "Masło ubić na jasny krem razem z cukrem pudrem i kakao (ok. 5 minut). Dodać jajko i ubijać jeszcze przez ok. 3 minuty.",
                "300000, 180000"),
                GetStep(recipe, 3,
                "W oddzielnej misce wymieszać mąkę z sodą oczyszczoną i proszkiem do pieczenia. Przesypać do ubitej masy i wymieszać."),
                GetStep(recipe, 4,
                "Masę podzielić na około 13 części. Formować placuszki, na środku kłaść po kostce czekolady i zlepiać dokładnie brzegi ciasta. Układać na blaszkę wyłożoną papierem do pieczenia."),
                GetStep(recipe, 5,
                "Wstawić do nagrzanego piekarnika i piec przez ok. 13 minut.",
                "780000")
            };
        }



        private Recipe GetRecipe4EN()
        {
            Recipe recipe = GetRecipe("en", "Cookies with chocolate", 13, "50 min", "foto_4.jpg");
            recipe.Ingredients = GetIngredients4EN(recipe);
            recipe.Steps = GetSteps4EN(recipe);

            return recipe;
        }

        private List<Ingredient> GetIngredients4EN(Recipe recipe)
        {
            return new List<Ingredient>()
            {
                GetIngredient(recipe, "100 g czekolady deserowej", "Chocolate"),
                GetIngredient(recipe, "100 g masła", "Butter"),
                GetIngredient(recipe, "1/2 szklanki cukru pudru", "PowderedSugar"),
                GetIngredient(recipe, "2 łyżki kakao", "Cocoa"),
                GetIngredient(recipe, "1 egg", "Eggs"),
                GetIngredient(recipe, "220 g of wheat flour", "Flour"),
                GetIngredient(recipe, "1/2 teaspoon of baking soda", "BakingSoda"),
                GetIngredient(recipe, "1/4 teaspoon of baking powder", "BakingPowder")
            };
        }

        private List<Step> GetSteps4EN(Recipe recipe)
        {
            return new List<Step>()
            {
                GetStep(recipe, 1,
                "Divide the chocolate into cubes. Cut butter and heat at room temperature. Heat the oven to 180 degrees C."),
                GetStep(recipe, 2,
                "Whisk butter with light cream together with powdered sugar and cocoa (about 5 minutes). Add the egg and beat for about 3 minutes.",
                "300000, 180000"),
                GetStep(recipe, 3,
                "In a separate bowl, mix the flour with baking soda and baking powder. Sprinkle to a packed mass and mix."),
                GetStep(recipe, 4,
                "Divide the mass into about 13 parts. Shape the pancakes, put in the middle of the chocolate bar and stick the edges of the dough exactly. Arrange on a baking tray lined with baking paper."),
                GetStep(recipe, 5,
                "Put in a preheated oven and bake for about 13 minutes.",
                "780000")
            };
        }



        private Recipe GetRecipe5PL()
        {
            Recipe recipe = GetRecipe("pl", "Jaglanka z jagodami", 1, "30 min", "foto_5.jpg");
            recipe.Ingredients = GetIngredients5PL(recipe);
            recipe.Steps = GetSteps5PL(recipe);

            return recipe;
        }

        private List<Ingredient> GetIngredients5PL(Recipe recipe)
        {
            return new List<Ingredient>()
            {
                GetIngredient(recipe, "1/4 szklanki kaszy jaglanej", "Millet"),
                GetIngredient(recipe, "1 szklanka mleka kokosowego", "CoconutMilk"),
                GetIngredient(recipe, "1/3 szklanki jagód", "Blueberries"),
                GetIngredient(recipe, "syrop klonowy", "MapleSyrup")
            };
        }

        private List<Step> GetSteps5PL(Recipe recipe)
        {
            return new List<Step>()
            {
                GetStep(recipe, 1,
                "Kaszę jaglaną wsypać do garnka, dokładnie wypłukać zmieniając ciepłą wodę. Wylać wodę, wlać mleko kokosowe, wymieszać i zagotować pod przykryciem."),
                GetStep(recipe, 2,
                "Ustawić garnek na najmniejszym palniku, zmniejszyć ogień do minimum i gotować pod przykryciem przez ok. 15 minut.",
                "900000"),
                GetStep(recipe, 3,
                "Wyłożyć do miseczki, posypać opłukanymi jagodami, skropić syropem klonowym.")
            };
        }



        private Recipe GetRecipe5EN()
        {
            Recipe recipe = GetRecipe("en", "Jaglanka with blueberries", 1, "30 min", "foto_5.jpg");
            recipe.Ingredients = GetIngredients5EN(recipe);
            recipe.Steps = GetSteps5EN(recipe);

            return recipe;
        }

        private List<Ingredient> GetIngredients5EN(Recipe recipe)
        {
            return new List<Ingredient>()
            {
                GetIngredient(recipe, "1/4 cup of millet", "Millet"),
                GetIngredient(recipe, "1 glass of coconut milk", "CoconutMilk"),
                GetIngredient(recipe, "1/3 cup of berries", "Blueberries"),
                GetIngredient(recipe, "Maple syrup", "MapleSyrup")
            };
        }

        private List<Step> GetSteps5EN(Recipe recipe)
        {
            return new List<Step>()
            {
                GetStep(recipe, 1,
                "Pour the millet into the pan, rinse thoroughly, changing the hot water. Pour out water, pour coconut milk, mix and boil under cover."),
                GetStep(recipe, 2,
                "Place the pot on the smallest burner, reduce the heat to a minimum and cook for about 15 minutes.",
                "900000"),
                GetStep(recipe, 3,
                "Put into a bowl, sprinkle with rinsed berries, sprinkle with maple syrup.")
            };
        }
        #endregion

        private Recipe GetRecipe(string CultureCode, string Name, int NoOfPortions, string PreparationTime, string ImageName)
        {
            return new Recipe()
            {
                ResourceCultureInfo = CultureCode,
                Name = Name,
                NoOfPortions = NoOfPortions,
                ImageName = ImageName,
                PreparationTime = PreparationTime
            };
        }

        private Ingredient GetIngredient(Recipe recipe, string Name, string ResourceKey)
        {
            return new Ingredient()
            {
                Name = Name,
                ForLater = false,
                IngredientResourceKey = ResourceKey
            };
        }

        private Step GetStep(Recipe recipe, int StepNumber, string Description, string timeSpans = null)
        {
            return new Step()
            {
                StepNumber = StepNumber,
                Description = Description,
                TimeSpans = timeSpans
            };
        }
    }
}
