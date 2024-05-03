import React from 'react'
import RecipeCard from './RecipeCard'
import '../styles/RecipeCardGrid.css'
import AddCard from './AddCard'

const RecipeCardGrid = () => {

  const recipeCards = [
    {title: 'Bagels'},
    {title: 'Sourdough Bread'},
    {title: 'Milk Rolls'},
    {title: 'Burger Buns'},
  ]

  const cards = recipeCards.map(recipeCard => <RecipeCard title={recipeCard.title}/>)

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