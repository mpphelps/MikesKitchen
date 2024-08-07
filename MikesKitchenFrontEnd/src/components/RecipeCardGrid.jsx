import React, { useEffect, useState } from 'react'
import axios from 'axios';
import RecipeCard from './RecipeCard'
import '../styles/RecipeCardGrid.css'
import AddCard from './AddCard'

const RecipeCardGrid = () => {

  const [recipes, setRecipes] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(()=> {
    const fetchRecipes = async () => {
      try {
        const response = await axios.get("https://localhost:7052/api/Recipe")
        setRecipes(response.data || []);
      } catch (error) {
        console.error("Error fetch recipes: ", error)
      } finally {
        setLoading(false);
      }
    };

    fetchRecipes();
  }, []);

if (loading) {
  return <div>Loading...</div>
}

  // const recipeCards = [
  //   {title: 'Bagels'},
  //   {title: 'Sourdough Bread'},
  //   {title: 'Milk Rolls'},
  //   {title: 'Burger Buns'},
  // ]

  // const cards = recipeCards.map(recipeCard => <RecipeCard title={recipeCard.title}/>)

  console.log(recipes);
  const cards = recipes.map((recipe) => (<RecipeCard key={recipe.Id} recipe={recipe}/>))

  return (
    <div className='recipe-card-grid-container'>
      <div className='recipe-card-grid-title'>
          RECIPES
      </div>
      <div className='recipe-card-grid'>
        {cards}
        <AddCard/>
      </div>
    </div>
    
  )
}

export default RecipeCardGrid