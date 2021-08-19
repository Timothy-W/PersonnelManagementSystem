<template>
  <header>
    <h1>{{ title }}</h1>
    <Button
      v-show="onHomePage"
      @btn-click="$emit('toggle-add-person')"
      :text="showAddPerson ? 'Close' : 'Add Person'"
      :color="showAddPerson ? 'red' : 'green'"
    />
  </header>
</template>


<script>
import Button from "../AppComponents/Button.vue";

export default {
  name: "PersonnelListHeader",
  //props: ['title'] // One way to define props
  props: {
    title: {
      type: String,
    },
    showAddPerson: Boolean,
  },
  components: {
    Button,
  },
  computed: {
    onHomePage() {
      if (this.$route.path === "/") {
        return true;
      } else {
        return false;
      }
    },
  },
};
</script>


<style scoped>
header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 20px;
}
</style>