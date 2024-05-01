import React from 'react'
import RecipeFilter from './RecipeFilter'
import RecipeCardGrid from './RecipeCardGrid'
import '../styles/RecipeCardArea.css'

const RecipeCardArea = () => {
  return (
    <div className='recipe-card-area'>
      <RecipeFilter/>
      <RecipeCardGrid/>
    </div>
  )
}

export default RecipeCardArea