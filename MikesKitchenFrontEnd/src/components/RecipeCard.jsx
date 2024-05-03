import React from 'react'
import '../styles/RecipeCard.css'

const RecipeCard = ({title}) => {
  return (
    <div className='recipe-card'>
      {title}
    </div>
  )
}

export default RecipeCard