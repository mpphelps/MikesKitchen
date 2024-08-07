import React from 'react'
import '../styles/RecipeCard.css'

const RecipeCard = ({recipe}) => {
  return (
    <div className='recipe-card'>
      <img src={recipe.pictureUrl} alt={recipe.name}/>
      <div>{recipe.title}</div>
    </div>
  )
}

export default RecipeCard