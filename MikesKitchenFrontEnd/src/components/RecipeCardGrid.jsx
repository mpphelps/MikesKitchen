import React from 'react'
import RecipeCard from './RecipeCard'
import '../styles/RecipeCardGrid.css'

const RecipeCardGrid = () => {
  return (
    <div className='recipe-card-grid-container'>
      <div className='recipe-card-grid-title'>
          RECIPES
      </div>
      <div className='recipe-card-grid'>
        <RecipeCard/>
        <RecipeCard/>
        <RecipeCard/>
        <RecipeCard/>
        <RecipeCard/>
      </div>
    </div>
    
  )
}

export default RecipeCardGrid